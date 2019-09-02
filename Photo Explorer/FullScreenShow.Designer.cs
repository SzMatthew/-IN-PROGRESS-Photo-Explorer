namespace Photo_Explorer
{
    partial class FullScreenShow
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.p_forward = new System.Windows.Forms.Panel();
            this.p_backward = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(913, 508);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            this.picBox.DoubleClick += new System.EventHandler(this.Form_DoubleClick);
            // 
            // p_forward
            // 
            this.p_forward.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_forward.Location = new System.Drawing.Point(803, 0);
            this.p_forward.Name = "p_forward";
            this.p_forward.Size = new System.Drawing.Size(110, 508);
            this.p_forward.TabIndex = 1;
            this.p_forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // p_backward
            // 
            this.p_backward.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_backward.Location = new System.Drawing.Point(0, 0);
            this.p_backward.Name = "p_backward";
            this.p_backward.Size = new System.Drawing.Size(110, 508);
            this.p_backward.TabIndex = 2;
            this.p_backward.Click += new System.EventHandler(this.Backward_Click);
            // 
            // FullScreenShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(913, 508);
            this.Controls.Add(this.p_backward);
            this.Controls.Add(this.p_forward);
            this.Controls.Add(this.picBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreenShow";
            this.ShowInTaskbar = false;
            this.Text = "FullScreenShow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.DoubleClick += new System.EventHandler(this.Form_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPress_Event);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel p_forward;
        private System.Windows.Forms.Panel p_backward;
    }
}