using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_Explorer
{
    public partial class Upload_Form : Form
    {
        //Global variables
        List<String> Photo_Path = new List<String>();
        //public Photo_Explorer PEForm;

        public Upload_Form()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(@"datasource=127.0.0.1;port=3306;database=photo_explorer;Username = root;Password=;CharSet=utf8");

        private void Browse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    String path = Path.GetFullPath(file);
                    String correctedPath = path.Replace(@"\", @"\\");
                    Photo_Path.Add(correctedPath);
                    lb_load.Visible = true;
                }
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            int albumID = 0;
            try
            {
                if (tb_albumName.Text == "")
                {
                    MessageBox.Show("Album name is empty!");
                }
                else
                {
                    //Insert the Album
                    MySqlCommand cmd = new MySqlCommand("Insert into Album (AlbumName) values('" + tb_albumName.Text + "' )", con);
                    cmd.CommandTimeout = 60;
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //Get the last Album ID
                    cmd = new MySqlCommand("Select LAST_INSERT_ID();", con);
                    cmd.CommandTimeout = 60;
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        albumID = Convert.ToInt32(rdr["LAST_INSERT_ID()"]);
                    }
                    con.Close();

                    //Upload Photos for the Album with ID above
                    for (int i=0; i<Photo_Path.Count; i++)
                    {
                        cmd = new MySqlCommand("Insert into Photo (Aperture, ShutterSpeed, Iso, PhotoData, AlbumID) values('1.8','1/100','100','" + Photo_Path[i] + "','" + albumID + "' )", con);
                        cmd.CommandTimeout = 60;
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    MessageBox.Show("Album have been uploaded!");

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}