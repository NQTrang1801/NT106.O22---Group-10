using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowExplorerUI
{
    public class FileSysItems : System.Collections.CollectionBase
    {
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

        SHFILEINFO shinfo = new SHFILEINFO();
        public IntPtr hFileImg;

        private readonly Form ParentForm;

        public FileSysItems() { }

        public FileSysItems(Form mainform)
        {
            ParentForm = mainform;
            FileItems = new ArrayList();
        }

        public LinkLabel this[int Index]
        {
            get
            {
                return (LinkLabel)this.List[Index];
            }
        }

        public void FSItemClick(Object sender, EventArgs e)
        {
            Explorer.prevpath = "";
            for (int i = 0; i < Explorer.frmExplorer.txtpath.Controls.Count; i++)
            {
                Explorer.prevpath += Explorer.frmExplorer.txtpath.Controls[i].Text.Trim();
            }

            int index = Explorer.frmExplorer.txtpath.Controls.GetChildIndex((LinkLabel)sender);
            string path = "";
            Explorer.presentpath = "";
            for (int i = 0; i <= index; i++)
            {
                path += Explorer.frmExplorer.txtpath.Controls[i].Text.Trim();
            }
            Explorer.presentpath = path;
            LoadUpdatedItems(path);
        }

        public ArrayList FileItems;

        public LinkLabel AddNewFItem(string itemName)
        {
            LinkLabel newItem = new LinkLabel();
            newItem.LinkBehavior = LinkBehavior.NeverUnderline;
            newItem.LinkColor = Color.Black;
            newItem.Cursor = Cursors.Arrow;
            newItem.VisitedLinkColor = Color.Red;
            newItem.Tag = this.Count;
            if (itemName.IndexOf("*") != -1 || itemName.IndexOf("?") != -1)
            {
                newItem.Text = itemName.Trim();
            }
            else
            {
                newItem.Text = itemName.Trim() + "\\";
            }

            newItem.Padding = Padding.Empty;
            newItem.Margin = Padding.Empty;
            newItem.BorderStyle = BorderStyle.None;
            newItem.Name = "temp" + DateTime.Now.ToLongTimeString().Replace(":", "").Replace("AM", "").Replace("PM", "");
            newItem.AutoSize = true;
            if (FileItems.Count == 0)
            {
                Explorer.frmExplorer.txtpath.Controls.Add(newItem);
            }
            else
            {
                object[] arrayitems = FileItems.ToArray();
                newItem.Left = ((LinkLabel)arrayitems[FileItems.Count - 1]).Location.X + ((LinkLabel)arrayitems[FileItems.Count - 1]).Width;
                Explorer.frmExplorer.txtpath.Controls.Add(newItem);
            }
            FileItems.Add(newItem);
            this.List.Add(newItem);
            newItem.Click += new EventHandler(FSItemClick);
            return newItem;
        }

        public void LoadUpdatedItems(string strpath)
        {
            try
            {
                if (!Directory.Exists(strpath))
                {
                    Explorer.frmExplorer.errorProvider1.SetError(Explorer.frmExplorer.txtpath, "Invalid Path...");
                    return;
                }
                else
                {
                    Explorer.frmExplorer.errorProvider1.SetError(Explorer.frmExplorer.txtpath, "");
                }
                Explorer.frmExplorer.lvitems.Items.Clear();
                DirectoryInfo dirinfo = new DirectoryInfo(strpath);
                FileSysItems fitems = new FileSysItems(Explorer.frmExplorer);
                Explorer.frmExplorer.txtpath.Text = "";
                Explorer.frmExplorer.txtpath.Controls.Clear();
                foreach (DirectoryInfo dinfo in dirinfo.GetDirectories())
                {

                    ListViewItem item = new ListViewItem();
                    item.Text = dinfo.Name;
                    item.ImageIndex = 1;
                    Explorer.frmExplorer.lvitems.Items.Add(item);
                }
                foreach (FileInfo dinfo in dirinfo.GetFiles())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dinfo.Name;
                    hFileImg = SHGetFileInfo(dinfo.FullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 0x1);
                    if (hFileImg != IntPtr.Zero)
                    {
                        Icon fileIcon = Icon.FromHandle(shinfo.hIcon);
                        Explorer.frmExplorer.imageList1.Images.Add(fileIcon);
                        item.ImageIndex = Explorer.frmExplorer.imageList1.Images.Count - 1;
                    }
                    Explorer.frmExplorer.lvitems.Items.Add(item);
                }
                foreach (string str in strpath.Split('\\'))
                {
                    if (str != "")
                        fitems.AddNewFItem(str);
                }

            }
            catch (Exception ex)
            {
                Explorer.frmExplorer.errLabel.Text = ex.Message;
            }
        }
    }
}
