using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_Explorer
{
    public partial class FullScreenShow : Form
    {
        private List<String> PhotoPaths = new List<String>();
        private String imagePath;
        Image image = null;

        public FullScreenShow(List<String> _paths, String _imagePath)
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            PhotoPaths = _paths;
            imagePath = _imagePath;
        }

        private void Form_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Forward_Click(object sender, EventArgs e)
        { 
            //Get screen size
            Form f = new Form();
            Screen myScreen = Screen.FromControl(f);
            Rectangle screenArea = myScreen.Bounds;
            int photoMaxSide = screenArea.Height;

            //Get index of actual picture
            int imageIndex = PhotoPaths.IndexOf(imagePath);

            //Get the following image
            if (imageIndex != PhotoPaths.Count - 1)
            {
                image = Image.FromFile(PhotoPaths[imageIndex + 1]);
                imagePath = PhotoPaths[imageIndex + 1];

                //Resize image to fit screen
                image = ResizeImage(image, GetOppositeSideSize(image.Height, photoMaxSide, image.Width), photoMaxSide);

                //Set the new picture to the picturebox
                picBox.Image = image;

                picBox.Refresh();
            }

            GC.Collect();
        }

        private void Backward_Click(object sender, EventArgs e)
        {
            //Get screen size
            Form f = new Form();
            Screen myScreen = Screen.FromControl(f);
            Rectangle screenArea = myScreen.Bounds;
            int photoMaxSide = screenArea.Height;

            //Get index of actual picture
            int imageIndex = PhotoPaths.IndexOf(imagePath);

            //Get the following image
            if (imageIndex != 0)
            {
                image = Image.FromFile(PhotoPaths[imageIndex - 1]);
                imagePath = PhotoPaths[imageIndex -1];

                //Resize image to fit screen
                image = ResizeImage(image, GetOppositeSideSize(image.Height, photoMaxSide, image.Width), photoMaxSide);

                //Set the new picture to the picturebox
                picBox.Image = image;

                picBox.Refresh();
            }

            GC.Collect();
        }

        private static int GetOppositeSideSize(int oldSize, float newSize, int otheroldSideSize)
        {
            float ratio = oldSize / newSize;
            return (int)(otheroldSideSize / ratio);
        }

        private static Image ResizeImage(Image source, int width, int height)
        {
            Image result = null;

            try
            {
                if (source.Width != width || source.Height != height)
                {
                    // Resize image
                    float sourceRatio = (float)source.Width / source.Height;

                    using (var target = new Bitmap(width, height))
                    {
                        using (var g = System.Drawing.Graphics.FromImage(target))
                        {
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;

                            // Scaling
                            float scaling;
                            float scalingY = (float)source.Height / height;
                            float scalingX = (float)source.Width / width;
                            if (scalingX < scalingY) scaling = scalingX; else scaling = scalingY;

                            int newWidth = (int)(source.Width / scaling);
                            int newHeight = (int)(source.Height / scaling);

                            // Correct float to int rounding
                            if (newWidth < width) newWidth = width;
                            if (newHeight < height) newHeight = height;

                            // See if image needs to be cropped
                            int shiftX = 0;
                            int shiftY = 0;

                            if (newWidth > width)
                            {
                                shiftX = (newWidth - width) / 2;
                            }

                            if (newHeight > height)
                            {
                                shiftY = (newHeight - height) / 2;
                            }

                            // Draw image
                            g.DrawImage(source, -shiftX, -shiftY, newWidth, newHeight);
                        }

                        result = (Image)target.Clone();
                    }
                }
                else
                {
                    // Image size matched the given size
                    result = (Image)source.Clone();
                }
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

        private void KeyPress_Event(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Forward_Click(sender, e);
            }

            if (e.KeyCode == Keys.Left)
            {
                Backward_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
