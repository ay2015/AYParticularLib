using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace WpfApplication4.APS
{
    /// <summary>
    /// 对颜色的拓展
    /// Ay   www.ayjs.net
    /// 2016-6-30 17:29:42
    /// </summary>
    public static class AyColorExtension
    {


        public static Color Create(byte r, byte g, byte b)
        {
            return Color.FromArgb(1, r, g, b);
        }
        public static Color Copy(this Color color)
        {
            Color c1 = new Color();
            c1.R = color.R;
            c1.G = color.G;
            c1.B = color.B;
            c1.A = color.A;
            return c1;
        }

        public static Color Add(this Color color, Color color2)
        {
            return color + color2;
        }

        public static Color Multiply(this Color color, float s)
        {
            return color * s;
        }

        public static Color Modulate(this Color color, Color color2)
        {
            Color c1 = new Color();
            c1.R = (byte)(color.R * color2.R);
            c1.G = (byte)(color.G * color2.G);
            c1.B = (byte)(color.B * color2.B);
            c1.A = color.A;
            return c1;
        }

        public static void Saturate(this Color color)
        {
            color.R = Math.Min(color.R, (byte)1);
            color.G = Math.Min(color.G, (byte)1);
            color.B = Math.Min(color.B, (byte)1);
        }


    }
}
