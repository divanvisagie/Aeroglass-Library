/*********************************************
 * Author: Divan Visagie
 * Email: snip3r8@gmail.com
 * License: LGPL (meaning you are allowed to
 * use an unmodified version of the library 
 * in a commercial application)
 * 
 * This file allows easy creation of 
 * glass regions on a wpf window.
 * It sets particular margins for window
 * frame and sets the window background to 
 * transparent in order to expose the extended
 * frame
 * *******************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Import wpf related libraries
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace AeroGlass
{
    public class WpfGlass
    {
        private Brush defaultColor = Brushes.White;/*The background of the form is set to this color when aero
                                                    is not enabled*/

        public Brush DefaultColor 
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

        //this override allows you to set the default color when calling extendframe
        public void extendFrame(int top, int bottom, int left, int right, Window window, Brush DefaultColor)
        {
            defaultColor = DefaultColor;
            extendFrame(top, bottom, left, right, window);
        }
        public void extendFrame(int top, int bottom, int left, int right,Window window)
        {
            try
            {
                //set the form background to transparent
                window.Background = Brushes.Transparent;
                // Get the window handle
                IntPtr mainWindowPtr = new WindowInteropHelper(window).Handle;
                HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
                mainWindowSrc.CompositionTarget.BackgroundColor = Color.FromArgb(0, 0, 0, 0);

                // Get the system dpi values
                System.Drawing.Graphics desktop = System.Drawing.Graphics.FromHwnd(mainWindowPtr);
                float DpiX = desktop.DpiX;
                float pDpiY = desktop.DpiY;

                // Set Margins
                Margins margins = new Margins();

                margins.Left = Convert.ToInt32((left + 5) * (DpiX / 96));
                margins.Right = Convert.ToInt32((right + 5) * (DpiX / 96));
                margins.Top = Convert.ToInt32((top + 5) * (DpiX / 96));
                margins.Bottom = Convert.ToInt32((bottom + 5) * (DpiX / 96));

                int check = GlassApi.DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);
                
                if (check < 0)
                {
                    //Cannot extend frame so set background to default
                    window.Background = defaultColor;
                }
            }
            // If aero is not supported paint the background default
            catch (DllNotFoundException)
            {
                window.Background = defaultColor;
            }
        }
    }
}
