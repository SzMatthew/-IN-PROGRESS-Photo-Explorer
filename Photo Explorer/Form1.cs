using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_Explorer
{
    public partial class Photo_Explorer : Form
    {
        private MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString);
        private List<Button> albumNameButtons = new List<Button>();
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private List<String> PhotoPaths = new List<String>();
        private readonly int spacer = 10;
        private readonly int photosInRow = 3;
        private Image image = null;
        private Label lb_albumNameOnPanel = new Label();

        public Photo_Explorer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 30);
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            Upload_Form uploadForm = new Upload_Form();

            //uploadForm.Show();
            uploadForm.ShowDialog();

            //If upload form is closed Refresh the Menu
            RefreshAlbumNames();
        }

        private void Dowload_Albums(object sender, PaintEventArgs e)
        {
            List<String> AlbumNames = new List<String>();

            //Dowload album names
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select AlbumName From Album;", con);
                cmd.CommandTimeout = 60;
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AlbumNames.Add(Convert.ToString(rdr["AlbumName"]));
                }

                con.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Can't connect to database!\nPlease start Xampp!");
            }
            finally
            {
                con.Close();
            }

            //Create Album Buttons
            for (int i = 0; i < AlbumNames.Count; i++)
            {
                Button nameButton = new Button();
                nameButton.Height = 50;
                nameButton.Width = p_menu.Width-20;
                nameButton.Location = new Point(0, i * nameButton.Height);
                nameButton.FlatStyle = FlatStyle.Flat;
                nameButton.Font = new System.Drawing.Font("Segoe Script", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                nameButton.Text = AlbumNames[i];
                nameButton.ForeColor = System.Drawing.SystemColors.ControlText;
                nameButton.Margin = new System.Windows.Forms.Padding(0);
                nameButton.FlatAppearance.BorderSize = 0;
                nameButton.UseVisualStyleBackColor = false;
                nameButton.TabIndex = 0;
                nameButton.Click += new EventHandler((piece, k) => NameButton_Click(sender, e, nameButton.Text));
                nameButton.Visible = true;
                p_menu.Controls.Add(nameButton);
                albumNameButtons.Add(nameButton);
            }
        }

        private void NameButton_Click(object sender, EventArgs e, string albumName)
        {
            //Remove Photos from screen
            DisposePhotos();

            int selectedAlbumID = -1;
            //List<String> photoPaths = new List<String>();

            //Get selected album ID
            MySqlCommand cmd = new MySqlCommand("Select ID From Album WHERE AlbumName = @albumname;", con);
            cmd.Parameters.AddWithValue("@albumname", albumName);
            cmd.CommandTimeout = 60;
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                selectedAlbumID = Convert.ToInt32(rdr["ID"]);
            }
            con.Close();

            //Dowload photo paths
            cmd = new MySqlCommand("Select * From Photo WHERE  AlbumID= '" + selectedAlbumID + "';", con);
            cmd.CommandTimeout = 60;
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                PhotoPaths.Add(Convert.ToString(rdr["PhotoData"]));
            }
            //Console.WriteLine(photoPaths.Count);
            
            con.Close();

            //Print images
            PrintPhotosFromFile(PhotoPaths, albumName);
        }

        private async void PrintPhotosFromFile(List<String> paths, String albumName)
        {
            lb_albumNameOnPanel.Text = albumName;
            lb_albumNameOnPanel.Font = new System.Drawing.Font("Segoe Script", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            lb_albumNameOnPanel.ForeColor = Color.White;
            lb_albumNameOnPanel.Visible = true;
            lb_albumNameOnPanel.Location = new Point(((p_photos.Width-100) / 2) - lb_albumNameOnPanel.Width/2, 40);
            lb_albumNameOnPanel.BorderStyle = BorderStyle.None;
            lb_albumNameOnPanel.AutoSize = true;


            p_photos.Controls.Add(lb_albumNameOnPanel);

            int firstColoumY = 150;
            int secondColoumY = 150;
            int thirdColoumY = 150;
            int heightDifference;

            for (int i=0; i<paths.Count; i++)
            {
                if (firstColoumY <= secondColoumY && firstColoumY <= thirdColoumY)
                {
                    heightDifference = await Task.Run(() => ShowPicture(paths[i], spacer, firstColoumY + spacer));
                    p_photos.Controls.Add(pictureBoxes[i]);
                    GC.Collect();
                    firstColoumY = firstColoumY + heightDifference + spacer;
                }

                else if (secondColoumY <= firstColoumY && secondColoumY <= thirdColoumY)
                {
                    heightDifference = await Task.Run(() => ShowPicture(paths[i], 2*spacer + (p_photos.Width - 20 - (4 * spacer)) / 3, secondColoumY + spacer));
                    p_photos.Controls.Add(pictureBoxes[i]);
                    GC.Collect();
                    secondColoumY = secondColoumY + heightDifference + spacer;
                }

                else if (thirdColoumY <= firstColoumY && thirdColoumY <= secondColoumY)
                {
                    heightDifference = await Task.Run(() => ShowPicture(paths[i], spacer + 2*(spacer + (p_photos.Width - 20 - (4 * spacer)) / 3), thirdColoumY + spacer));
                    p_photos.Controls.Add(pictureBoxes[i]);
                    GC.Collect();
                    thirdColoumY = thirdColoumY + heightDifference + spacer;
                }
                p_photos.Refresh();
            }
        }

        public static int GetOppositeSideSize(int oldSize, float newSize, int otheroldSideSize)
        {
            float ratio = oldSize / newSize;
            return (int)(otheroldSideSize / ratio);
        }

        public static Image ResizeImage(Image source, int width, int height)
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

        private int ShowPicture(String ImagePath, int X, int Y)
        {
            image = Image.FromFile(ImagePath);
            int photoMaxWidth = ((p_photos.Width-20) - (4 * spacer)) / photosInRow;
            image = ResizeImage(image, photoMaxWidth, GetOppositeSideSize(image.Width, photoMaxWidth, image.Height));
            int heightDifference = 0;

            PictureBox Photo = new PictureBox();
            Photo.Image = image;
            Photo.Width = image.Width;
            Photo.Height = image.Height;
            Photo.Location = new Point(X, Y);
            Photo.Padding = new Padding(0, 0, 0, 0);
            Photo.Visible = true;
            Photo.Click += new EventHandler((sender, e) => Photo_Click(sender, e, ImagePath));

            heightDifference += Photo.Height;
            pictureBoxes.Add(Photo);
        
            return heightDifference;
        }

        private void Photo_Click(object sender, EventArgs e, String ImagePath)
        {
            Form Form1 = new Form();
            Screen myScreen = Screen.FromControl(Form1);
            Rectangle screenArea = myScreen.Bounds;

            image = Image.FromFile(ImagePath);
            int photoMaxSide = screenArea.Height;
            image = ResizeImage(image, GetOppositeSideSize(image.Height, photoMaxSide, image.Width), photoMaxSide);

            FullScreenShow f = new FullScreenShow(PhotoPaths, ImagePath);
            f.picBox.Image = image;
            f.Show();
        }

        private void DisposePhotos()
        {
            for (int i=0; i<pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Hide();
                p_photos.Controls.Remove(pictureBoxes[i]);
            }
            lb_albumNameOnPanel.Hide();
            p_photos.Controls.Remove(lb_albumNameOnPanel);

            pictureBoxes.RemoveRange(0, pictureBoxes.Count);

            PhotoPaths.RemoveRange(0, PhotoPaths.Count);
        }

        private void FullScreenDetect(object sender, EventArgs e)
        {
            Console.WriteLine("Most");

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].Hide();
                p_photos.Controls.Remove(pictureBoxes[i]);
            }
            pictureBoxes.RemoveRange(0, pictureBoxes.Count);
            PrintPhotosFromFile(PhotoPaths, lb_albumNameOnPanel.Text);
            p_photos.Refresh();
        }

        private void AddPicture_Click(object sender, EventArgs e)
        {

        }

        private void DeleteAlbum_Click(object sender, EventArgs e)
        {
            int selectedAlbumID = -1;

            MySqlCommand cmd = new MySqlCommand("Select ID From Album WHERE AlbumName = @albumname;", con);
            cmd.Parameters.AddWithValue("@albumname", lb_albumNameOnPanel.Text);
            cmd.CommandTimeout = 60;
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                selectedAlbumID = Convert.ToInt32(rdr["ID"]);
            }
            con.Close();

            cmd = new MySqlCommand("DELETE FROM Photo WHERE AlbumID = @albumID;", con);
            cmd.Parameters.AddWithValue("@albumID", selectedAlbumID);
            cmd.CommandTimeout = 60;
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();

            cmd = new MySqlCommand("DELETE FROM Album WHERE ID = @ID;", con);
            cmd.Parameters.AddWithValue("@ID", selectedAlbumID);
            cmd.CommandTimeout = 60;
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();

            DisposePhotos();

            RefreshAlbumNames();
        }

        private void RefreshAlbumNames()
        {
            foreach (Button button in albumNameButtons)
            {
                button.Dispose();
            }
            p_menu.Refresh();
            p_menu.AutoScrollPosition = new Point(0, 0);
        }
    }
}
