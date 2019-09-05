namespace Photo_Explorer
{
    partial class Photo_Explorer
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
        public void InitializeComponent()
        {
            this.p_menu = new System.Windows.Forms.Panel();
            this.p_photos = new System.Windows.Forms.Panel();
            this.bt_addPic = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.lb_albumsName = new System.Windows.Forms.Label();
            this.b_upload = new System.Windows.Forms.Button();
            this.p_photos.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_menu
            // 
            this.p_menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.p_menu.AutoScroll = true;
            this.p_menu.BackColor = System.Drawing.SystemColors.GrayText;
            this.p_menu.Location = new System.Drawing.Point(0, 56);
            this.p_menu.Name = "p_menu";
            this.p_menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.p_menu.Size = new System.Drawing.Size(245, 884);
            this.p_menu.TabIndex = 0;
            this.p_menu.Paint += new System.Windows.Forms.PaintEventHandler(this.Dowload_Albums);
            // 
            // p_photos
            // 
            this.p_photos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_photos.AutoScroll = true;
            this.p_photos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.p_photos.Controls.Add(this.bt_addPic);
            this.p_photos.Controls.Add(this.bt_delete);
            this.p_photos.Location = new System.Drawing.Point(225, 0);
            this.p_photos.Name = "p_photos";
            this.p_photos.Size = new System.Drawing.Size(1490, 980);
            this.p_photos.TabIndex = 1;
            // 
            // bt_addPic
            // 
            this.bt_addPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_addPic.BackColor = System.Drawing.Color.Transparent;
            this.bt_addPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_addPic.Image = global::Photo_Explorer.Properties.Resources.AddPic;
            this.bt_addPic.Location = new System.Drawing.Point(1428, 38);
            this.bt_addPic.Name = "bt_addPic";
            this.bt_addPic.Size = new System.Drawing.Size(20, 20);
            this.bt_addPic.TabIndex = 1;
            this.bt_addPic.UseVisualStyleBackColor = false;
            this.bt_addPic.Click += new System.EventHandler(this.AddPicture_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_delete.BackColor = System.Drawing.Color.Transparent;
            this.bt_delete.FlatAppearance.BorderSize = 0;
            this.bt_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_delete.Image = global::Photo_Explorer.Properties.Resources.transparentX;
            this.bt_delete.Location = new System.Drawing.Point(1428, 12);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(20, 20);
            this.bt_delete.TabIndex = 0;
            this.bt_delete.UseVisualStyleBackColor = false;
            this.bt_delete.Click += new System.EventHandler(this.DeleteAlbum_Click);
            // 
            // lb_albumsName
            // 
            this.lb_albumsName.AutoSize = true;
            this.lb_albumsName.Font = new System.Drawing.Font("Segoe Script", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_albumsName.Location = new System.Drawing.Point(12, 9);
            this.lb_albumsName.Name = "lb_albumsName";
            this.lb_albumsName.Size = new System.Drawing.Size(206, 44);
            this.lb_albumsName.TabIndex = 2;
            this.lb_albumsName.Text = "Your Albums";
            // 
            // b_upload
            // 
            this.b_upload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_upload.BackColor = System.Drawing.SystemColors.GrayText;
            this.b_upload.FlatAppearance.BorderSize = 0;
            this.b_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_upload.Font = new System.Drawing.Font("Segoe Script", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.b_upload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.b_upload.Location = new System.Drawing.Point(0, 915);
            this.b_upload.Margin = new System.Windows.Forms.Padding(0);
            this.b_upload.Name = "b_upload";
            this.b_upload.Size = new System.Drawing.Size(225, 45);
            this.b_upload.TabIndex = 0;
            this.b_upload.Text = "Upload Album";
            this.b_upload.UseVisualStyleBackColor = false;
            this.b_upload.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // Photo_Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1695, 959);
            this.Controls.Add(this.b_upload);
            this.Controls.Add(this.lb_albumsName);
            this.Controls.Add(this.p_photos);
            this.Controls.Add(this.p_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Photo_Explorer";
            this.Text = "Photo Explorer";
            this.ClientSizeChanged += new System.EventHandler(this.FullScreenDetect);
            this.p_photos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel p_photos;
        public System.Windows.Forms.Panel p_menu;
        public System.Windows.Forms.Button b_upload;
        public System.Windows.Forms.Label lb_albumsName;
        public System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_addPic;
    }
}

