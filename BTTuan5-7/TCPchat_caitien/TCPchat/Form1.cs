using SuperSimpleTcp;
using System.Net.Sockets;
using System.Text;

namespace TCPchat
{
    public partial class Form1 : Form
    {
        private string selectImage;
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;



        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                btSend.Enabled = true;
                btConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new(tbIP.Text);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
            btSend.Enabled = false;
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
                    AddTextChat("Server: ");

                    tbinfo.ScrollToCaret();

                    return;
                }
                tbinfo.SelectionAlignment = HorizontalAlignment.Left;
                AddTextChat($"Server: {Encoding.UTF8.GetString(e.Data)}");

            });
        }

        private void Events_Disconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tbinfo.Text += $"Server disconnected.{Environment.NewLine}";
            });
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tbinfo.Text += $"Server connected.{Environment.NewLine}";
            });
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (tbmessage.Text.StartsWith("[Image]") && selectImage != null)
                {
                    Image image = Image.FromFile(selectImage);
                    client.Send(selectImage);

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
                client.Send(tbmessage.Text);
                tbinfo.SelectionAlignment = HorizontalAlignment.Right;
                AddTextChat($"You: {tbmessage.Text}");

                tbmessage.Text = string.Empty;
                tbinfo.AppendText(Environment.NewLine);

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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
