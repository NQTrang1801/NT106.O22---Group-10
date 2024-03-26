using SuperSimpleTcp;
using System.Text;

namespace TCPchat
{
    public partial class Form1 : Form
    {
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
            client = new (tbIP.Text);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
            btSend.Enabled = false;
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                tbinfo.Text += $"Server: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
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
            if(client.IsConnected)
            {
                if(!string.IsNullOrEmpty(tbmessage.Text))
                {
                    client.Send(tbmessage.Text);
                    tbinfo.Text += $"Me: {tbmessage.Text}{Environment.NewLine}";
                    tbmessage.Text=string.Empty;
                }    
            }    
        }
    }
}
