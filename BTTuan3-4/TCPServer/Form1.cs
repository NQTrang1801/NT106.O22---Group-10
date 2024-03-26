using SuperSimpleTcp;
using System.Security.Cryptography;
using System.Text;

namespace TCPServer
{
    public partial class Form1 : Form
    {
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
                tbinfo.Text += $"{e.IpPort}: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
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
                if (!string.IsNullOrEmpty(tbmessage.Text) && lbClientIP.SelectedItems != null)
                {
                    server.Send(lbClientIP.SelectedItems.ToString(), tbmessage.Text);
                    tbinfo.Text += $"Server: {tbmessage.Text}{Environment.NewLine}";
                    tbmessage.Text = string.Empty;
                }
            }
        }


    } 
}

