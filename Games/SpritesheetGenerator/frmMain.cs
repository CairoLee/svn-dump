using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SpritesheetGenerator
{
    public partial class frmMain : Form
    {
        private List<string> mFilepaths = new List<string>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOpenFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Images|*.png;*.jpg;*.bmp;*.gif";
                dlg.Multiselect = true;
                if (dlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                string[] files = dlg.FileNames;
                foreach (string filepath in files)
                {
                    AddFile(filepath);
                }
            }
        }

        private void btnImageUp_Click(object sender, EventArgs e)
        {
            if (listFiles.Items.Count == 0 || listFiles.SelectedIndex == -1)
            {
                return;
            }
            // Out of range (lower)
            if (listFiles.SelectedIndex == 0)
            {
                return;
            }

            ListViewItem item = (ListViewItem)listFiles.Items[listFiles.SelectedIndex - 1];
            listFiles.Items[listFiles.SelectedIndex - 1] = listFiles.SelectedItem;
            listFiles.Items[listFiles.SelectedIndex] = item;
        }

        private void btnImageDown_Click(object sender, EventArgs e)
        {
            if (listFiles.Items.Count == 0 || listFiles.SelectedIndex == -1)
            {
                return;
            }
            // Out of range (upper)
            if (listFiles.SelectedIndex+1 >= listFiles.Items.Count) {
                return;
            }

            ListViewItem item = (ListViewItem)listFiles.Items[listFiles.SelectedIndex + 1];
            listFiles.Items[listFiles.SelectedIndex + 1] = listFiles.SelectedItem;
            listFiles.Items[listFiles.SelectedIndex] = item;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int imageWidth = int.Parse(txtImageWidth.Text);
            int imageHeight = int.Parse(txtImageHeight.Text);
            int imagesPerRow = int.Parse(txtImagesPerRow.Text);

            Generate(imageWidth, imageHeight, imagesPerRow);
        }



        private void AddFile(string filepath)
        {
            mFilepaths.Add(filepath);
            listFiles.Items.Add(Path.GetFileName(filepath));
        }

        private void Generate(int imageFrameWidth, int imageFrameHeight, int imagesPerRow)
        {
            List<Bitmap> images = new List<Bitmap>();
            foreach (string filepath in mFilepaths)
            {
                images.Add(Bitmap.FromFile(filepath) as Bitmap);
            }

            int imageWidth = (imageFrameWidth * imagesPerRow);
            int imageHeight = imageFrameHeight * (images.Count / imagesPerRow);
            using (Bitmap spritesheet = new Bitmap(imageWidth, imageHeight))
            {
                using (Graphics g = Graphics.FromImage(spritesheet))
                {
                    int x = 0;
                    int y = 0;
                    int i = 0;
                    foreach (Bitmap frame in images)
                    {
                        Point p = new Point();
                        p.X = (x + (imageFrameWidth / 2) - (frame.Width / 2));
                        p.Y = (y * imageFrameHeight);
                        g.DrawImageUnscaled(frame, p);
                       
                        i++;
                        x += imageFrameWidth;
                        if (i >= imagesPerRow)
                        {
                            y++;
                            x = 0;
                            i = 0;
                        }
                    }
                }

                string imagepath = Environment.CurrentDirectory + @"\Spriteshet.png";
                if (File.Exists(imagepath))
                {
                    File.Delete(imagepath);
                }
                spritesheet.Save(imagepath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

    }

}
