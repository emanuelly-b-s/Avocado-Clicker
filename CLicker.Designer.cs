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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clicker));
            panel1 = new System.Windows.Forms.Panel();
            clickerTxt = new System.Windows.Forms.Label();
            avocado = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avocado).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(clickerTxt);
            panel1.Controls.Add(avocado);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(800, 450);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // clickerTxt
            // 
            clickerTxt.AutoSize = true;
            clickerTxt.Location = new System.Drawing.Point(69, 31);
            clickerTxt.Name = "clickerTxt";
            clickerTxt.Size = new System.Drawing.Size(0, 20);
            clickerTxt.TabIndex = 1;
            clickerTxt.Click += label1_Click;
            // 
            // avocado
            // 
            avocado.BackColor = System.Drawing.Color.Transparent;
            avocado.Cursor = System.Windows.Forms.Cursors.Hand;
            avocado.Image = Properties.Resources.avocado;
            avocado.Location = new System.Drawing.Point(3, 54);
            avocado.Name = "avocado";
            avocado.Size = new System.Drawing.Size(178, 172);
            avocado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            avocado.TabIndex = 0;
            avocado.TabStop = false;
            avocado.Click += avocado_clicker;
            // 
            // Clicker
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panel1);
            Name = "Clicker";
            Text = "Clicker";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)avocado).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox avocado;
        private System.Windows.Forms.Label clickerTxt;
    }
}