﻿namespace TCPchat
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
            label2 = new Label();
            tbmessage = new TextBox();
            btSend = new Button();
            button1 = new Button();
            button2 = new Button();
            tbinfo = new RichTextBox();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 430);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 0;
            label2.Text = "Message";

            // 
            // tbmessage
            // 
            tbmessage.Location = new Point(112, 430);
            tbmessage.Name = "tbmessage";
            tbmessage.Size = new Size(447, 31);
            tbmessage.TabIndex = 1;

            // 
            // btSend
            // 
            btSend.Location = new Point(589, 428);
            btSend.Name = "btSend";
            btSend.Size = new Size(112, 34);
            btSend.TabIndex = 2;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
            // 
            // button1
            // 
            button1.Location = new Point(111, 466);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 3;
            button1.Text = "Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(229, 467);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 3;
            button2.Text = "Emoji";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tbinfo
            // 
            tbinfo.Location = new Point(111, 72);
            tbinfo.Name = "tbinfo";
            tbinfo.Size = new Size(590, 350);
            tbinfo.TabIndex = 4;
            tbinfo.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 566);
            Controls.Add(tbinfo);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btSend);
            Controls.Add(btConnect);
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
        private Label label2;
        private TextBox tbmessage;
        private Button btSend;
        private Button button1;
        private Button button2;
        private RichTextBox tbinfo;
    }
}