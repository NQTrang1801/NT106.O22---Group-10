namespace FileSystemExplorer
{
    partial class Explorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.bntgo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpath = new System.Windows.Forms.RichTextBox();
            this.lvitems = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarkItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInWindowsExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statextra = new System.Windows.Forms.StatusStrip();
            this.tsdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tstime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.errLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrtime = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.statextra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bntgo
            // 
            this.bntgo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntgo.Location = new System.Drawing.Point(1235, 24);
            this.bntgo.Margin = new System.Windows.Forms.Padding(4);
            this.bntgo.Name = "bntgo";
            this.bntgo.Size = new System.Drawing.Size(65, 34);
            this.bntgo.TabIndex = 5;
            this.bntgo.Text = "&Go";
            this.bntgo.UseVisualStyleBackColor = true;
            this.bntgo.Click += new System.EventHandler(this.bntgo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(19, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path:";
            // 
            // txtpath
            // 
            this.txtpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpath.BackColor = System.Drawing.Color.White;
            this.txtpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpath.ForeColor = System.Drawing.Color.Black;
            this.txtpath.Location = new System.Drawing.Point(62, 24);
            this.txtpath.Margin = new System.Windows.Forms.Padding(0);
            this.txtpath.Multiline = false;
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(1163, 32);
            this.txtpath.TabIndex = 3;
            this.txtpath.Text = "";
            this.txtpath.Click += new System.EventHandler(this.txtpath_Click);
            this.txtpath.TextChanged += new System.EventHandler(this.txtpath_TextChanged);
            this.txtpath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpath_KeyDown);
            this.txtpath.Leave += new System.EventHandler(this.txtpath_Leave);
            // 
            // lvitems
            // 
            this.lvitems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvitems.ContextMenuStrip = this.contextMenuStrip1;
            this.lvitems.HideSelection = false;
            this.lvitems.LargeImageList = this.imageList1;
            this.lvitems.Location = new System.Drawing.Point(4, 68);
            this.lvitems.Margin = new System.Windows.Forms.Padding(4);
            this.lvitems.Name = "lvitems";
            this.lvitems.ShowItemToolTips = true;
            this.lvitems.Size = new System.Drawing.Size(1311, 667);
            this.lvitems.SmallImageList = this.imageList1;
            this.lvitems.StateImageList = this.imageList1;
            this.lvitems.TabIndex = 6;
            this.lvitems.UseCompatibleStateImageBehavior = false;
            this.lvitems.View = System.Windows.Forms.View.List;
            this.lvitems.DoubleClick += new System.EventHandler(this.lvitems_DoubleClick);
            this.lvitems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvitems_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.bookmarkItToolStripMenuItem,
            this.openInWindowsExplorerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(311, 76);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem,
            this.tileToolStripMenuItem,
            this.iconToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(310, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.tileToolStripMenuItem.Text = "Tile";
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.tileToolStripMenuItem_Click);
            // 
            // iconToolStripMenuItem
            // 
            this.iconToolStripMenuItem.Name = "iconToolStripMenuItem";
            this.iconToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.iconToolStripMenuItem.Text = "Icon";
            this.iconToolStripMenuItem.Click += new System.EventHandler(this.iconToolStripMenuItem_Click);
            // 
            // bookmarkItToolStripMenuItem
            // 
            this.bookmarkItToolStripMenuItem.Name = "bookmarkItToolStripMenuItem";
            this.bookmarkItToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.bookmarkItToolStripMenuItem.Size = new System.Drawing.Size(310, 24);
            this.bookmarkItToolStripMenuItem.Text = "Bookmark It";
            this.bookmarkItToolStripMenuItem.Click += new System.EventHandler(this.bookmarkItToolStripMenuItem_Click);
            // 
            // openInWindowsExplorerToolStripMenuItem
            // 
            this.openInWindowsExplorerToolStripMenuItem.Name = "openInWindowsExplorerToolStripMenuItem";
            this.openInWindowsExplorerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.openInWindowsExplorerToolStripMenuItem.Size = new System.Drawing.Size(310, 24);
            this.openInWindowsExplorerToolStripMenuItem.Text = "Open in Windows Explorer";
            this.openInWindowsExplorerToolStripMenuItem.Click += new System.EventHandler(this.openInWindowsExplorerToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "drive.jpg");
            this.imageList1.Images.SetKeyName(1, "folder.gif");
            this.imageList1.Images.SetKeyName(2, "Text.bmp");
            // 
            // statextra
            // 
            this.statextra.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statextra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdate,
            this.tstime,
            this.toolStripProgressBar1,
            this.errLabel});
            this.statextra.Location = new System.Drawing.Point(0, 744);
            this.statextra.Name = "statextra";
            this.statextra.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statextra.Size = new System.Drawing.Size(1316, 23);
            this.statextra.TabIndex = 7;
            // 
            // tsdate
            // 
            this.tsdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsdate.Name = "tsdate";
            this.tsdate.Size = new System.Drawing.Size(158, 17);
            this.tsdate.Text = "toolStripStatusLabel1";
            // 
            // tstime
            // 
            this.tstime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tstime.Name = "tstime";
            this.tstime.Size = new System.Drawing.Size(158, 17);
            this.tstime.Text = "toolStripStatusLabel2";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 17);
            this.toolStripProgressBar1.Visible = false;
            // 
            // errLabel
            // 
            this.errLabel.Name = "errLabel";
            this.errLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // tmrtime
            // 
            this.tmrtime.Enabled = true;
            this.tmrtime.Tick += new System.EventHandler(this.tmrtime_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1316, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 767);
            this.Controls.Add(this.statextra);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lvitems);
            this.Controls.Add(this.bntgo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpath);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Explorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Explorer...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Explorer_FormClosing);
            this.Load += new System.EventHandler(this.Explorer_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statextra.ResumeLayout(false);
            this.statextra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button bntgo;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox txtpath;
        public System.Windows.Forms.ListView lvitems;
        private System.Windows.Forms.StatusStrip statextra;
        private System.Windows.Forms.Timer tmrtime;
        private System.Windows.Forms.ToolStripStatusLabel tsdate;
        private System.Windows.Forms.ToolStripStatusLabel tstime;
        public System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iconToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bookmarkItToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        public System.Windows.Forms.ToolStripStatusLabel errLabel;
        private System.Windows.Forms.ToolStripMenuItem openInWindowsExplorerToolStripMenuItem;
    }
}

