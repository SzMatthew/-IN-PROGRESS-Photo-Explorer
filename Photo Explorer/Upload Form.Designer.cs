namespace Photo_Explorer
{
    partial class Upload_Form
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
            this.lb_albumName = new System.Windows.Forms.Label();
            this.tb_albumName = new System.Windows.Forms.TextBox();
            this.lb_Photos = new System.Windows.Forms.Label();
            this.b_browse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lb_load = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_albumName
            // 
            this.lb_albumName.AutoSize = true;
            this.lb_albumName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_albumName.Location = new System.Drawing.Point(13, 13);
            this.lb_albumName.Name = "lb_albumName";
            this.lb_albumName.Size = new System.Drawing.Size(115, 20);
            this.lb_albumName.TabIndex = 0;
            this.lb_albumName.Text = "Album Name:";
            // 
            // tb_albumName
            // 
            this.tb_albumName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb_albumName.Location = new System.Drawing.Point(135, 12);
            this.tb_albumName.Name = "tb_albumName";
            this.tb_albumName.Size = new System.Drawing.Size(156, 23);
            this.tb_albumName.TabIndex = 1;
            // 
            // lb_Photos
            // 
            this.lb_Photos.AutoSize = true;
            this.lb_Photos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Photos.Location = new System.Drawing.Point(59, 61);
            this.lb_Photos.Name = "lb_Photos";
            this.lb_Photos.Size = new System.Drawing.Size(70, 20);
            this.lb_Photos.TabIndex = 2;
            this.lb_Photos.Text = "Photos:";
            // 
            // b_browse
            // 
            this.b_browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.b_browse.Location = new System.Drawing.Point(135, 56);
            this.b_browse.Name = "b_browse";
            this.b_browse.Size = new System.Drawing.Size(156, 30);
            this.b_browse.TabIndex = 3;
            this.b_browse.Text = "Browse";
            this.b_browse.UseVisualStyleBackColor = true;
            this.b_browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(17, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(274, 44);
            this.button1.TabIndex = 4;
            this.button1.Text = "Upload Album";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Upload_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Multiselect = true;
            // 
            // lb_load
            // 
            this.lb_load.AutoSize = true;
            this.lb_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_load.Location = new System.Drawing.Point(10, 104);
            this.lb_load.Name = "lb_load";
            this.lb_load.Size = new System.Drawing.Size(295, 20);
            this.lb_load.TabIndex = 5;
            this.lb_load.Text = "Photos have been successfully choosen!";
            this.lb_load.Visible = false;
            // 
            // Upload_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(317, 197);
            this.Controls.Add(this.lb_load);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_browse);
            this.Controls.Add(this.lb_Photos);
            this.Controls.Add(this.tb_albumName);
            this.Controls.Add(this.lb_albumName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Upload_Form";
            this.Text = "Upload Album";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_albumName;
        public System.Windows.Forms.TextBox tb_albumName;
        private System.Windows.Forms.Label lb_Photos;
        private System.Windows.Forms.Button b_browse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lb_load;
    }
}