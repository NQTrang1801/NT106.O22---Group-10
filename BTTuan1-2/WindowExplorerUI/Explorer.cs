using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Management;
using System.Runtime.InteropServices;

namespace FileSystemExplorer
{
        
    public partial class Explorer : Form
    {
        #region Code for getting File Icon
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };
        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        public IntPtr hFileImg;
        SHFILEINFO shinfo = new SHFILEINFO();
        #endregion
        public static Explorer frmExplorer;
        public static string prevpath,presentpath; 
        public Explorer()
        {
            InitializeComponent();
       }
     private void Explorer_Load(object sender, EventArgs e)
        {
            //To Load all Drives
            LoadAllDrives();
            tsdate.Text = DateTime.Now.ToLongDateString();
        }
        private void tmrtime_Tick(object sender, EventArgs e)
        {
            //To Load updated time in Status bar
            tstime.Text = DateTime.Now.ToLongTimeString();
        }

        private void bntgo_Click(object sender, EventArgs e)
        {
            string path=GetPath();
            if(path != "")
            LoadUpdatedItems(path);
        }
         public void LoadUpdatedItems(string strpath)
        {
            try
            {
            lvitems.Items.Clear();
            DirectoryInfo dirinfo2 = new DirectoryInfo(strpath);
            FileSysItems fitems2 = new  FileSysItems(frmExplorer);
            foreach(DirectoryInfo dinfo in dirinfo2.GetDirectories())
            {
            
               ListViewItem item = new  ListViewItem();
                item.Text = dinfo.Name;
                item.ImageIndex = 1;
                lvitems.Items.Add(item);
            }
            foreach(FileInfo  dinfo in dirinfo2.GetFiles())
            {
                ListViewItem item = new  ListViewItem();
                item.Text = dinfo.Name;
                hFileImg = SHGetFileInfo(dinfo.FullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 0x1);
                if (hFileImg != IntPtr.Zero)
                {
                    Icon fileIcon = Icon.FromHandle(shinfo.hIcon);
                    imageList1.Images.Add(fileIcon);
                    item.ImageIndex = imageList1.Images.Count - 1;
                }
                lvitems.Items.Add(item);
            }
            txtpath.Text = "";
            txtpath.Controls.Clear();
              foreach(string str in strpath.Split('\\'))
              {
               if(str != "")
                  fitems2.AddNewFItem(str);
              }
              toolStripProgressBar1.Value = 100;
            }
            catch(Exception ex)
            {
                if (ex.Message.IndexOf("Thread was") == -1)
                {
                    Explorer.frmExplorer.errLabel.Text = ex.Message;
                }
            }
        }

        private void lvitems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //To Open selected Dir or File.
                string selected = "";
                bool isFile =false;
                bool isRecentExist = false;
                ListViewItem selItem = null;
           foreach(ListViewItem item in lvitems.Items)
            {
                if(item.Selected)
                {
                    selected = item.Text;
                    selItem = item;
                    if (item.ImageIndex != 1 && item.ImageIndex != 0)
                    {
                        isFile = true;
                    }
                    break;
                }
            }
           if (!isFile)
           {
               for (int i = 3; i < imageList1.Images.Count - 1; i++)
               {
                   imageList1.Images.RemoveAt(i);
               }
           }
                string path = "";
                FileSysItems fitems1 = new  FileSysItems(frmExplorer);
                if(txtpath.Controls.Count > 0)
                {
                for(int i=0;i<txtpath.Controls.Count;i++)
                {
                    path+=Explorer.frmExplorer.txtpath.Controls[i].Text.Trim();
                }
                    path+=selected;
                    selected = path;
                }
                if(selected.IndexOf(@"\") == -1)
                {
                    if(!txtpath.Text.EndsWith(@"\"))
                    {
                    selected = txtpath.Text.Trim()+"\\"+selected;
                    }
                    else
                    {
                        selected = txtpath.Text.Trim()+selected;
                    }
                }
                if(isFile)
                {
                    string path1 = "";
                     selected="";
                for(int i=0;i<txtpath.Controls.Count;i++)
                {
                    path1+=Explorer.frmExplorer.txtpath.Controls[i].Text.Trim();
                }
                    path1+=selected;
                    selected = path1;
                    Process pr = new  System.Diagnostics.Process();
                    if (lvitems.SelectedItems[0] != null)
                    {
                        selected += lvitems.SelectedItems[0].Text;
                    }
                    //For recursive Search items,Tooltip property will have complete path.
                    if (selItem.ToolTipText != "")
                    {
                        selected = selItem.ToolTipText.Trim();
                    }
                    try
                    {
                        ProcessStartInfo info = new ProcessStartInfo(selected);
                        info.WindowStyle = ProcessWindowStyle.Normal;
                        pr.StartInfo = info;
                        pr.Start();
                        
                    }
                    catch 
                    {
                        ProcessStartInfo info = new ProcessStartInfo("explorer", path1);
                        info.WindowStyle = ProcessWindowStyle.Normal;
                        pr.StartInfo = info;
                        pr.Start();
                    }
                    return;
                }
            if(!Directory.Exists(selected.Trim()))
            {
                errorProvider1.SetError(txtpath,"Invalid Path...");
                return;
            }
            else
            {
                   errorProvider1.SetError(txtpath,"");
            }
            lvitems.Items.Clear();
            DirectoryInfo dirinfo = new DirectoryInfo(selected.Trim());
            FileSysItems fitems = new  FileSysItems(frmExplorer);
            txtpath.Text = selected;
            foreach(DirectoryInfo dinfo in dirinfo.GetDirectories())
            {
                
               ListViewItem item1= new  ListViewItem();
                item1.Text = dinfo.Name;
                item1.ImageIndex = 1;

                lvitems.Items.Add(item1);
            }
            foreach(FileInfo  dinfo in dirinfo.GetFiles())
            {
                ListViewItem item = new  ListViewItem();
                item.Text = dinfo.Name;
                hFileImg = SHGetFileInfo(dinfo.FullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 0x1);
                if (hFileImg != IntPtr.Zero)
                {
                    Icon fileIcon = Icon.FromHandle(shinfo.hIcon);
                    imageList1.Images.Add(fileIcon);
                    item.ImageIndex = imageList1.Images.Count - 1;
                }
                lvitems.Items.Add(item);
            }
                     txtpath.Controls.Clear();
              foreach(string str in selected.Split('\\'))
              {
               if(str != "")
                  fitems.AddNewFItem(str);
              }
              if (lvitems.Items.Count > 0)
              {
                  lvitems.Items[0].Selected = true;
              }
            }
            catch(Exception ex)
            {
                Explorer.frmExplorer.errLabel.Text = ex.Message;
            }
        }
        public void BookmarkItemsClick(Object sender, System.EventArgs e)
        {
            try
            {
                LoadUpdatedItems(((ToolStripItem)sender).Text);
            }
            catch { }
        }
        public void recentItemsClick(Object sender, System.EventArgs e)
        {
            try
            {
                //Its A File Path
                Process pr = new Process();
                ProcessStartInfo info = new ProcessStartInfo(((ToolStripItem)sender).Text);
                info.WindowStyle = ProcessWindowStyle.Normal;
                pr.StartInfo = info;
                pr.Start();
            }
            catch { }
        }
        private void txtpath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadUpdatedItems(txtpath.Text.Trim());
                return;
            }
            if(e.KeyCode == Keys.Down)
            {
                lvitems.Select();
            }
            if(e.KeyCode == Keys.Left)
            {
                try
                {
                    string path = Explorer.presentpath;
                    if (!Directory.Exists(path.Trim()))
                    {
                        errorProvider1.SetError(txtpath, "Invalid Path...");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtpath, "");
                    }
                    lvitems.Items.Clear();
                    DirectoryInfo dirinfo = new DirectoryInfo(path.Trim());
                    FileSysItems fitems = new FileSysItems(frmExplorer);
                    txtpath.Text = "";
                    foreach (DirectoryInfo dinfo in dirinfo.GetDirectories())
                    {

                        ListViewItem item = new ListViewItem();
                        item.Text = dinfo.Name;
                        item.ImageIndex = 1;
                        lvitems.Items.Add(item);
                    }
                    foreach (FileInfo dinfo in dirinfo.GetFiles())
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = dinfo.Name;
                        hFileImg = SHGetFileInfo(dinfo.FullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 0x1);
                        if (hFileImg != IntPtr.Zero)
                        {
                            Icon fileIcon = Icon.FromHandle(shinfo.hIcon);
                            imageList1.Images.Add(fileIcon);
                            item.ImageIndex = imageList1.Images.Count - 1;
                        }
                        lvitems.Items.Add(item);
                    }
                    txtpath.Controls.Clear();
                    foreach (string str in path.Split('\\'))
                    {
                        if (str != "")
                            fitems.AddNewFItem(str);
                    }

                }
                catch (Exception ex)
                {
                    Explorer.frmExplorer.errLabel.Text = ex.Message;
                }

                return;
            }

            if(e.KeyCode == Keys.Right)
            {
                try
                {
                    string path = Explorer.prevpath;
                    if (!Directory.Exists(path.Trim()))
                    {
                        errorProvider1.SetError(txtpath, "Invalid Path...");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtpath, "");
                    }
                    lvitems.Items.Clear();
                    DirectoryInfo dirinfo = new DirectoryInfo(path.Trim());
                    FileSysItems fitems = new FileSysItems(frmExplorer);
                    txtpath.Text = "";
                    foreach (DirectoryInfo dinfo in dirinfo.GetDirectories())
                    {

                        ListViewItem item = new ListViewItem();
                        item.Text = dinfo.Name;
                        item.ImageIndex = 1;
                        lvitems.Items.Add(item);
                    }
                    foreach (FileInfo dinfo in dirinfo.GetFiles())
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = dinfo.Name;
                        hFileImg = SHGetFileInfo(dinfo.FullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 0x1);
                        if (hFileImg != IntPtr.Zero)
                        {
                            Icon fileIcon = Icon.FromHandle(shinfo.hIcon);
                            imageList1.Images.Add(fileIcon);
                            item.ImageIndex = imageList1.Images.Count - 1;
                        }
                        lvitems.Items.Add(item);
                    }
                    txtpath.Controls.Clear();
                    foreach (string str in path.Split('\\'))
                    {
                        if (str != "")
                            fitems.AddNewFItem(str);
                    }

                }
                catch
                {
                }
                return;
            }
            if (e.KeyCode == Keys.Back)
            {
                //Check for Drives Display..
                if (txtpath.Controls.Count == 1)
                {
                    LoadAllDrives();
                    return;
                }
                string path = "";
                for (int i = 0; i < txtpath.Controls.Count - 1; i++)
                {
                    path += txtpath.Controls[i].Text.Trim();
                }
                try
                {
                    prevpath = txtpath.Text;
                    if (path.Trim() != "")
                    {
                        if (txtpath.Controls.Count > 1)
                        {
                            if (!Directory.Exists(path.Trim()))
                            {
                                errorProvider1.SetError(txtpath, "Invalid Path...");
                                return;
                            }
                            else
                            {
                                errorProvider1.SetError(txtpath, "");
                            }
                            lvitems.Items.Clear();
                            DirectoryInfo dirinfo = new DirectoryInfo(path.Trim());
                            FileSysItems fitems = new FileSysItems(frmExplorer);
                            txtpath.Text = "";
                            foreach (DirectoryInfo dinfo in dirinfo.GetDirectories())
                            {

                                ListViewItem item = new ListViewItem();
                                item.Text = dinfo.Name;
                                item.ImageIndex = 1;
                                lvitems.Items.Add(item);
                            }
                            foreach (FileInfo dinfo in dirinfo.GetFiles())
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = dinfo.Name;
                                hFileImg = SHGetFileInfo(dinfo.FullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 0x1);
                                if (hFileImg != IntPtr.Zero)
                                {
                                    Icon fileIcon = Icon.FromHandle(shinfo.hIcon);
                                    imageList1.Images.Add(fileIcon);
                                    item.ImageIndex = imageList1.Images.Count - 1;
                                }
                                lvitems.Items.Add(item);
                            }
                            txtpath.Controls.Clear();
                            foreach (string str in path.Split('\\'))
                            {
                                if (str != "")
                                    fitems.AddNewFItem(str);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Explorer.frmExplorer.errLabel.Text = ex.Message;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                notifyIcon1_Click(null, null);
            }
        }

        private void txtpath_Click(object sender, EventArgs e)
        {
               string path = "";
            if(txtpath.Controls.Count >0)
            {
                for(int i=0;i<txtpath.Controls.Count;i++)
                {
                    path+=Explorer.frmExplorer.txtpath.Controls[i].Text.Trim();
                }
            Explorer.frmExplorer.txtpath.Controls.Clear();
            txtpath.Text = path.Trim();
            }
        }

        private void txtpath_Leave(object sender, EventArgs e)
        {
            if(txtpath.Controls.Count==0)
            {
                FileSysItems fitems = new  FileSysItems(frmExplorer);
                  foreach(string str in txtpath.Text.Trim().Split('\\'))
              {
               if(str != "")
                  fitems.AddNewFItem(str);
              }
            }
        }

        private void lvitems_KeyDown(object sender, KeyEventArgs e)
        {
            string path = "";
            if(e.KeyCode == Keys.Enter)
            {
                lvitems_DoubleClick(null,null);
                return;
            }
            if (e.KeyCode == Keys.Back)
            {
                //Check for Drives Display..
                if (txtpath.Controls.Count == 1)
                {
                    LoadAllDrives();
                    return;
                }
                for (int i = 0; i < txtpath.Controls.Count - 1; i++)
                {
                    path += txtpath.Controls[i].Text.Trim();
                }
                try
                {
                    prevpath = txtpath.Text;
                    if (txtpath.Controls.Count > 1)
                    {
                        if (!Directory.Exists(path.Trim()))
                        {
                            errorProvider1.SetError(txtpath, "Invalid Path...");
                            return;
                        }
                        else
                        {
                            errorProvider1.SetError(txtpath, "");
                        }

                        lvitems.Items.Clear();
                        DirectoryInfo dirinfo = new DirectoryInfo(path.Trim());
                        FileSysItems fitems = new FileSysItems(frmExplorer);
                        txtpath.Text = "";
                        foreach (DirectoryInfo dinfo in dirinfo.GetDirectories())
                        {

                            ListViewItem item = new ListViewItem();
                            item.Text = dinfo.Name;
                            item.ImageIndex = 1;
                            lvitems.Items.Add(item);
                        }
                        foreach (FileInfo dinfo in dirinfo.GetFiles())
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = dinfo.Name;
                            hFileImg = SHGetFileInfo(dinfo.FullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 0x1);
                            if (hFileImg != IntPtr.Zero)
                            {
                                Icon fileIcon = Icon.FromHandle(shinfo.hIcon);
                                imageList1.Images.Add(fileIcon);
                                item.ImageIndex = imageList1.Images.Count - 1;
                            }
                            lvitems.Items.Add(item);
                        }
                        txtpath.Controls.Clear();
                        foreach (string str in path.Split('\\'))
                        {
                            if (str != "")
                                fitems.AddNewFItem(str);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Explorer.frmExplorer.errLabel.Text = ex.Message;
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                notifyIcon1_Click(null, null);
            }
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvitems.View = View.List;
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvitems.View = View.Tile;
        }

        private void iconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvitems.View = View.SmallIcon;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvitems.View = View.Details;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bookmarkItToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            if (Explorer.frmExplorer.txtpath.Text != "")
            {
                path = Explorer.frmExplorer.txtpath.Text;
            }
            else
            {
                for (int i = 0; i < Explorer.frmExplorer.txtpath.Controls.Count; i++)
                {
                    path += Explorer.frmExplorer.txtpath.Controls[i].Text.Trim();
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Explorer.presentpath;
                if (!Directory.Exists(path.Trim()))
                {
                    errorProvider1.SetError(txtpath, "Invalid Path...");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtpath, "");
                }
                lvitems.Items.Clear();
                DirectoryInfo dirinfo = new DirectoryInfo(path.Trim());
                FileSysItems fitems = new FileSysItems(frmExplorer);
                txtpath.Text = "";
                foreach (DirectoryInfo dinfo in dirinfo.GetDirectories())
                {

                    ListViewItem item = new ListViewItem();
                    item.Text = dinfo.Name;
                    item.ImageIndex = 1;
                    lvitems.Items.Add(item);
                }
                foreach (FileInfo dinfo in dirinfo.GetFiles())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dinfo.Name;
                    hFileImg = SHGetFileInfo(dinfo.FullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 0x1);
                    if (hFileImg != IntPtr.Zero)
                    {
                        Icon fileIcon = Icon.FromHandle(shinfo.hIcon);
                        imageList1.Images.Add(fileIcon);
                        item.ImageIndex = imageList1.Images.Count - 1;
                    }
                    lvitems.Items.Add(item);
                }
                txtpath.Controls.Clear();
                foreach (string str in path.Split('\\'))
                {
                    if (str != "")
                        fitems.AddNewFItem(str);
                }

            }
            catch { }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Explorer.prevpath;
                if (!Directory.Exists(path.Trim()))
                {
                    errorProvider1.SetError(txtpath, "Invalid Path...");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtpath, "");
                }
                lvitems.Items.Clear();
                DirectoryInfo dirinfo = new DirectoryInfo(path.Trim());
                FileSysItems fitems = new FileSysItems(frmExplorer);
                txtpath.Text = "";
                foreach (DirectoryInfo dinfo in dirinfo.GetDirectories())
                {

                    ListViewItem item = new ListViewItem();
                    item.Text = dinfo.Name;
                    item.ImageIndex = 1;
                    lvitems.Items.Add(item);
                }
                foreach (FileInfo dinfo in dirinfo.GetFiles())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dinfo.Name;
                    hFileImg = SHGetFileInfo(dinfo.FullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 0x1);
                    if (hFileImg != IntPtr.Zero)
                    {
                        Icon fileIcon = Icon.FromHandle(shinfo.hIcon);
                        imageList1.Images.Add(fileIcon);
                        item.ImageIndex = imageList1.Images.Count - 1;
                    }
                    lvitems.Items.Add(item);
                }
                txtpath.Controls.Clear();
                foreach (string str in path.Split('\\'))
                {
                    if (str != "")
                        fitems.AddNewFItem(str);
                }

            }
            catch{   }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (frmExplorer.Visible)
            {
                frmExplorer.Visible = false;
            }
            else
            {
                frmExplorer.Visible = true;
            }
        }
        public void LoadAllDrives()
        {
            //Load All Drives..
            lvitems.Items.Clear();
            txtpath.Controls.Clear();
            foreach (DriveInfo drinfo in DriveInfo.GetDrives())
            {
                ListViewItem item = new ListViewItem();
                item.Text = drinfo.Name;
                item.ImageIndex = 0;
                lvitems.Items.Add(item);
            }
            if (lvitems.Items.Count > 0)
            {
                lvitems.Focus();
                lvitems.Items[0].Selected = true;
            }
        }
        private void Explorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("c:\\bookmark.txt", false);
                writer.Flush();
                writer.Close();
                notifyIcon1.Visible = false;
                notifyIcon1.Dispose();
            }
            catch { }
        }
        private string GetPath()
        {
            string path = "";
            if (txtpath.Text.Trim() != "")
            {
                path = txtpath.Text.Trim();
            }
            else
            {
                for (int i = 0; i < txtpath.Controls.Count; i++)
                {
                    path += Explorer.frmExplorer.txtpath.Controls[i].Text.Trim();
                }
            }
            return path;
        }

        private void openInWindowsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "";
                if (txtpath.Text.Trim() != "")
                {
                    path = txtpath.Text.Trim();
                }
                else if (txtpath.Controls.Count > 0)
                {
                    for (int i = 0; i < txtpath.Controls.Count; i++)
                    {
                        path += txtpath.Controls[i].Text;
                    }
                }
                if (path != "")
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo("explorer", path);
                    p.Start();
                }
            }
            catch { }
        }
    }
}