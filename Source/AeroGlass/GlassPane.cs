using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AeroGlass
{
    public partial class GlassPane : UserControl 
    {
        static Color transColor = Color.FromArgb(255, 221, 220, 220);

        private bool autoExt = false;/*The glass frams will automatically be extended 
                                       * if this value is true and the glass pane is 
                                       * docked*/
        private Color defaultColor = Color.White;

        Glass g = new Glass();
        public GlassPane()
        {
            InitializeComponent();            
        }

        public Color DefaultColor /*if glass is not enabled the 
                                   * control is set to this color */
        {
            get 
            {
                return defaultColor;
            }
            set 
            {
                defaultColor = value;
            }
        }

        public bool AutoExtend
        {            
            get 
            {
                return autoExt;
            }
            set
            {
                autoExt = value;
            }
        }

        private void GlassPane_Load(object sender, EventArgs e)
        {
            if (GlassApi.IsGlassEnabled())
                this.BackColor = transColor;
            else
                this.BackColor = defaultColor;

            if (autoExt)
            {
                //if the form is docked,automatically initialize glass
                if (this.Dock == DockStyle.Bottom)
                {
                    g.extendFrame(0, this.Height, 0, 0, this.ParentForm);
                }
                else if (this.Dock == DockStyle.Top)
                {
                    g.extendFrame(this.Height, 0, 0, 0, this.ParentForm);
                }
                else if (this.Dock == DockStyle.Left)
                {
                    g.extendFrame(0, 0, this.Width, 0, this.ParentForm);
                }
                else if (this.Dock == DockStyle.Right)
                {
                    g.extendFrame(0, 0, 0, this.Width, this.ParentForm);
                }
                else if (this.Dock == DockStyle.Fill)
                {
                    g.extendFrame(this.ParentForm);
                }
            }
        }
    }
}
