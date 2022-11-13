using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Net.Mail;

namespace GraphDrawerAddin
{
    internal class FontSettings
    {

        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        public static void InstallFonts()
        {
            string outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            int result = -1;
            int error = 0;

            Dictionary<string, string> fontDict= new Dictionary<string, string>()
            {
                {"rm", @"..\..\fonts\lmroman10-regular.otf" },
                {"it", @"..\..\fonts\lmroman10-italic.otf" },
                {"bd", @"..\..\fonts\lmroman10-bold.otf" },
                {"bdit", @"..\..\fonts\lmroman10-bolditalic.otf" }
            };

            foreach (var font in fontDict.Values)
            {
                result = AddFontResource(new Uri(Path.Combine(outPutDirectory, font)).LocalPath);
                error = Marshal.GetLastWin32Error();

                if (error != 0)
                {
                    MessageBox.Show("LMRoman10 폰트 설치 과정 중 오류가 발생했습니다." + new Win32Exception(error).Message);
                    MessageBox.Show(new Uri(Path.Combine(outPutDirectory, font)).LocalPath);
                    return;
                }
            }

            if (error == 0)
                MessageBox.Show((result == 0) ? "LMRoman10 폰트가 이미 설치되어 있습니다.":
                    "LMRoman10 폰트가 설치되었습니다. 파워포인트를 재실행해주세요.");
        }

    }
}
