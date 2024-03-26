namespace TCPchat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbIP = new TextBox();
            btConnect = new Button();
            tbinfo = new TextBox();
            label2 = new Label();
            tbmessage = new TextBox();
            btSend = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 33);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 0;
            label1.Text = "server";
            // 
            // tbIP
            // 
            tbIP.Location = new Point(112, 33);
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(447, 31);
            tbIP.TabIndex = 1;
            tbIP.Text = "127.0.0.1:9000";
            // 
            // btConnect
            // 
            btConnect.Location = new Point(589, 33);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(112, 34);
            btConnect.TabIndex = 2;
            btConnect.Text = "Connect";
            btConnect.UseVisualStyleBackColor = true;
            btConnect.Click += btConnect_Click;
            // 
            // tbinfo
            // 
            tbinfo.Location = new Point(112, 70);
            tbinfo.Multiline = true;
            tbinfo.Name = "tbinfo";
            tbinfo.ReadOnly = true;
            tbinfo.ScrollBars = ScrollBars.Both;
            tbinfo.Size = new Size(589, 248);
            tbinfo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 337);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 0;
            label2.Text = "Message";
            // 
            // tbmessage
            // 
            tbmessage.Location = new Point(112, 337);
            tbmessage.Name = "tbmessage";
            tbmessage.Size = new Size(447, 31);
            tbmessage.TabIndex = 1;
            // 
            // btSend
            // 
            btSend.Location = new Point(589, 335);
            btSend.Name = "btSend";
            btSend.Size = new Size(112, 34);
            btSend.TabIndex = 2;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 450);
            Controls.Add(btSend);
            Controls.Add(btConnect);
            Controls.Add(tbinfo);
            Controls.Add(tbmessage);
            Controls.Add(label2);
            Controls.Add(tbIP);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "TCP/IP Client";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbIP;
        private Button btConnect;
        private TextBox tbinfo;
        private Label label2;
        private TextBox tbmessage;
        private Button btSend;
    }
}
