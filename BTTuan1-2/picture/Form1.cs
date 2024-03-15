
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Picture
{
    public partial class Form1 : Form

    {
        private string[] imagePaths;
        private int currentIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBoxMain_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePaths = openFileDialog.FileNames;
                    LoadImage(currentIndex);
                }
            }
        }
        private void LoadImage(int index)
        {
            if (imagePaths == null || index < 0 || index >= imagePaths.Length)
                return;

            pictureBoxMain.Image = Image.FromFile(imagePaths[index]);
            pictureBoxMain.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (imagePaths == null || imagePaths.Length == 0)
                return;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    currentIndex = (currentIndex == 0) ? imagePaths.Length - 1 : currentIndex - 1;
                    LoadImage(currentIndex);
                    break;
                case Keys.Right:
                    currentIndex = (currentIndex == imagePaths.Length - 1) ? 0 : currentIndex + 1;
                    LoadImage(currentIndex);
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
    }
}



