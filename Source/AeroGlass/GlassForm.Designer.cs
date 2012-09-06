namespace AeroGlass
{
    partial class GlassForm
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
            this.glassPane1 = new AeroGlass.GlassPane();
            this.SuspendLayout();
            // 
            // glassPane1
            // 
            
            this.glassPane1.BackColor = System.Drawing.Color.Transparent;
            this.glassPane1.DefaultColor = System.Drawing.Color.White;
            this.glassPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glassPane1.Location = new System.Drawing.Point(0, 0);
            this.glassPane1.Name = "glassPane1";
            this.glassPane1.Size = new System.Drawing.Size(329, 271);
            this.glassPane1.TabIndex = 0;
            // 
            // GlassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 271);
            this.Controls.Add(this.glassPane1);
            this.Name = "GlassForm";
            this.Text = "GlassForm";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Load += new System.EventHandler(this.GlassForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GlassPane glassPane1;


    }
}