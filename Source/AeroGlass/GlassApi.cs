using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AeroGlass
{
    public class GlassApi //provides access to the DWM API
    {
        //import dwmapi.dll      
        [DllImport("dwmapi.dll")]
        internal static extern int DwmExtendFrameIntoClientArea(System.IntPtr hWnd, ref Margins pMargins);

        [DllImport("dwmapi.dll")]
        internal static extern void DwmIsCompositionEnabled(ref bool isEnabled);

        public static bool IsGlassEnabled()//Check if glass is enabled on the system
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                return false;
            }            
            bool isGlassSupported = false;
            GlassApi.DwmIsCompositionEnabled(ref isGlassSupported);
            return isGlassSupported;
        }
    }
}
