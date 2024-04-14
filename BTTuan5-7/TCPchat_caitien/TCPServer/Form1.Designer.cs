namespace TCPServer
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
            btStart = new Button();
            label2 = new Label();
            tbmessage = new TextBox();
            btSend = new Button();
            lbClientIP = new ListBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            tbinfo = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(732, 211);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
            label1.TabIndex = 0;
            label1.Text = "Client IP";
            label1.Click += label1_Click;
            // 
            // tbIP
            // 
            tbIP.Location = new Point(112, 33);
            tbIP.Name = "tbIP";
            tbIP.Size = new Size(447, 31);
            tbIP.TabIndex = 1;
            tbIP.Text = "127.0.0.1:9000";
            tbIP.TextChanged += textBox1_TextChanged;
            // 
            // btStart
            // 
            btStart.Location = new Point(447, 70);
            btStart.Name = "btStart";
            btStart.Size = new Size(112, 34);
            btStart.TabIndex = 2;
            btStart.Text = "Start";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 125);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 0;
            label2.Text = "Message";
            // 
            // tbmessage
            // 
            tbmessage.Location = new Point(112, 125);
            tbmessage.Name = "tbmessage";
            tbmessage.Size = new Size(447, 31);
            tbmessage.TabIndex = 1;
            tbmessage.TextChanged += textBox1_TextChanged;
            // 
            // btSend
            // 
            btSend.Location = new Point(447, 168);
            btSend.Name = "btSend";
            btSend.Size = new Size(112, 34);
            btSend.TabIndex = 2;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
            // 
            // lbClientIP
            // 
            lbClientIP.FormattingEnabled = true;
            lbClientIP.ItemHeight = 25;
            lbClientIP.Location = new Point(732, 241);
            lbClientIP.Name = "lbClientIP";
            lbClientIP.Size = new Size(281, 379);
            lbClientIP.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 33);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 0;
            label3.Text = "server";
            label3.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(112, 168);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(230, 168);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 5;
            button2.Text = "Emoji";
            button2.UseVisualStyleBackColor = true;
            // 
            // tbinfo
            // 
            tbinfo.Location = new Point(28, 208);
            tbinfo.Name = "tbinfo";
            tbinfo.Size = new Size(682, 412);
            tbinfo.TabIndex = 6;
            tbinfo.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 639);
            Controls.Add(tbinfo);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lbClientIP);
            Controls.Add(btSend);
            Controls.Add(btStart);
            Controls.Add(tbmessage);
            Controls.Add(label2);
            Controls.Add(tbIP);
            Controls.Add(label3);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "TCP/IP Server";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbIP;
        private Button btStart;
        private Label label2;
        private TextBox tbmessage;
        private Button btSend;
        private ListBox lbClientIP;
        private Label label3;
        private Button button1;
        private Button button2;
        private RichTextBox tbinfo;
    }
}
