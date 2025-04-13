using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class FontLoader
{
    public static PrivateFontCollection Fonts { get; private set; } = new PrivateFontCollection();

    static FontLoader()
    {
        LoadCustomFont("PongMasters.Assets.PressStart2P-Regular.ttf");
    }

    private static void LoadCustomFont(string resourceName)
    {
        using (Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        {
            if (fontStream != null)
            {
                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, (int)fontStream.Length);

                IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                Fonts.AddMemoryFont(fontPtr, fontData.Length);
                Marshal.FreeCoTaskMem(fontPtr);
            }
        }
    }

    public static Font GetFont(float size, FontStyle style = FontStyle.Regular)
    {
        return new Font(Fonts.Families[0], size, style);
    }
}