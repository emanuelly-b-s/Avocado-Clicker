namespace Avocado_Cliker
{
    partial class Clicker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            SuspendLayout();
            // 
            // pb
            // 
            pb.Dock = System.Windows.Forms.DockStyle.Fill;
            pb.Location = new System.Drawing.Point(0, 0);
            pb.Name = "pb";
            pb.Size = new System.Drawing.Size(937, 471);
            pb.TabIndex = 0;
            pb.TabStop = false;
            pb.MouseDown += pb_MouseDown;
            pb.MouseMove += pb_MouseMove;
            pb.MouseUp += pb_MouseUp;
            // 
            // Clicker
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(937, 471);
            Controls.Add(pb);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Clicker";
            Text = "Clicker";
            Load += Clicker_Load;
            Shown += Clicker_Shown;
            ((System.ComponentModel.ISupportInitialize)pb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
    }
}