/*********************************************
 * Author: Divan Visagie
 * Email: snip3r8@gmail.com
 * License: LGPL (meaning you are allowed to
 * use an unmodified version of the library 
 * in a commercial application)
 * 
 * This file allows easy creation of 
 * glass regions on a windows forms application.
 * It sets particular borders for the aero 
 * glass and sets panels to be glass areas
 * according to the color specified in 
 * transColor
 * *******************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AeroGlass
{
    public class Glass
    {
        //set the transparency key color
        static Color transColor = Color.FromArgb(255, 221, 220, 220);

        //initialize the glass areas of the form
        public void extendFrame(int Top, int Bottom, int Left, int Right, Form thisForm)
        {
            if (!GlassApi.IsGlassEnabled())
                return;

            //set glass margins
            Margins margins;
            margins.Top = Top;
            margins.Bottom = Bottom;
            margins.Left = Left;
            margins.Right = Right;

            Form f = new Form();
            f = thisForm;
            f.TransparencyKey = transColor;
            GlassApi.DwmExtendFrameIntoClientArea(f.Handle, ref margins);
        }

        //override for full glass form
        public void extendFrame(Form thisForm)
        {
            //int Top, int Bottom, int Left, int Right, 
           
            if (!GlassApi.IsGlassEnabled())
                return;

            //set glass margins
            Margins margins;
            margins.Top = -1;
            margins.Bottom = -1;
            margins.Left = -1;
            margins.Right = -1;

            Form f = new Form();
            f = thisForm;
            f.TransparencyKey = transColor;
            GlassApi.DwmExtendFrameIntoClientArea(f.Handle, ref margins);
        }

        //the transparent color property
        public Color TransparentColor
        {
            get
            {
                return transColor;
            }
        }
    }
    
}
