using SuperSimpleTcp;
using System.Security.Cryptography;
using System.Text;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        private string selectImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        SimpleTcpServer server;
        private void btStart_Click(object sender, EventArgs e)
        {
            server.Start();
            tbinfo.Text += $"Starting...{Environment.NewLine}";
            btStart.Enabled = false;
            btSend.Enabled = true;
        }

        private SimpleTcpServer GetServer()
        {
            return server;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btSend.Enabled = false;
            server = new(tbIP.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;

        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string dataString = Encoding.UTF8.GetString(e.Data);

                if (dataString.StartsWith("D:\\"))
                {
                    Image image = Image.FromFile(dataString);

                    Bitmap myBitmap = new Bitmap(image);
                    tbinfo.SelectionAlignment = HorizontalAlignment.Left;

                    AddImageChat(myBitmap);

                    AddTextChat($"{e.IpPort}: ");

                    tbinfo.ScrollToCaret();

                    return;
                }
                tbinfo.SelectionAlignment = HorizontalAlignment.Left;
                AddTextChat($"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}");

            });
        }

        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tbinfo.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";
                lbClientIP.Items.Remove(e.IpPort);
            });
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tbinfo.Text += $"{e.IpPort} connected.{Environment.NewLine}";
                lbClientIP.Items.Add(e.IpPort);
            });
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(tbmessage.Text) && lbClientIP.SelectedItem != null)
                {
                    if (tbmessage.Text.StartsWith("[Image]") && selectImage != null)
                    {
                        Image image = Image.FromFile(selectImage);
                        server.Send(lbClientIP.SelectedItem.ToString(), selectImage);

                        Bitmap myBitmap = new Bitmap(selectImage);

                        tbinfo.SelectionAlignment = HorizontalAlignment.Right;

                        AddImageChat(myBitmap);

                        AddTextChat("You: ");

                        tbmessage.Clear();


                        tbinfo.ScrollToCaret();

                        tbmessage.ReadOnly = false;
                        selectImage = null;
                        return;
                    }

                    server.Send(lbClientIP.SelectedItem.ToString(), tbmessage.Text);

                    tbinfo.SelectionAlignment = HorizontalAlignment.Right;

                    AddTextChat($"You: {tbmessage.Text}");

                    tbmessage.Text = string.Empty;
                    tbinfo.AppendText(Environment.NewLine);

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select image";
            fileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                tbmessage.Text = $"[Image] {fileDialog.SafeFileName}";
                tbmessage.ReadOnly = true;

                selectImage = fileDialog.FileName;
            }
        }
        private void AddImageChat(Bitmap bitmap)
        {
            tbinfo.Invoke((MethodInvoker)(() =>
            {
                int maxWidth = 150;
                int maxHeight = 150;

                int newWidth, newHeight;
                double aspectRatio = (double)bitmap.Width / bitmap.Height;

                if (aspectRatio > 1)
                {
                    newWidth = maxWidth;
                    newHeight = (int)(maxWidth / aspectRatio);
                }
                else
                {
                    newHeight = maxHeight;
                    newWidth = (int)(maxHeight * aspectRatio);
                }

                Bitmap resized = new Bitmap(bitmap, new Size(newWidth, newHeight));
                Clipboard.SetDataObject(resized);
                DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);

                tbinfo.ReadOnly = false;

                tbinfo.Select(tbinfo.Text.Length, 0);

                if (tbinfo.CanPaste(myFormat))
                {
                    tbinfo.Paste(myFormat);
                }

                tbinfo.ReadOnly = true;
            }));
            tbinfo.AppendText(Environment.NewLine);
            tbinfo.AppendText(Environment.NewLine);

        }
        private void AddTextChat(String mesage)
        {
            tbinfo.Invoke((MethodInvoker)(() =>
            {
                tbinfo.AppendText("  ");
                tbinfo.AppendText(" " + mesage + " ");
                tbinfo.AppendText(Environment.NewLine);
                tbinfo.AppendText(Environment.NewLine);

            }
            ));
        }
    }
}

