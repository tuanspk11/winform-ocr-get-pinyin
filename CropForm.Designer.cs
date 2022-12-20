namespace GetTextTool
{
    partial class CropForm
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
            this.pictureBoxArea = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArea)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxArea
            // 
            this.pictureBoxArea.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxArea.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxArea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxArea.Name = "pictureBoxArea";
            this.pictureBoxArea.Size = new System.Drawing.Size(10, 10);
            this.pictureBoxArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxArea.TabIndex = 0;
            this.pictureBoxArea.TabStop = false;
            // 
            // CropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.Controls.Add(this.pictureBoxArea);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CropForm";
            this.Text = "ImageCropper";
            this.VisibleChanged += new System.EventHandler(this.CropForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CropForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CropForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CropForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CropForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxArea;
    }
}