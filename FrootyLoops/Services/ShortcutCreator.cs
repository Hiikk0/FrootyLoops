using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FrootyLoops.Services
{
    public class ShortcutCreator
    {
        /// <summary>
        /// Створювач ярликів
        /// </summary>
        /// <param name="pathToFile"> Шлях до файлу</param>
        /// <param name="pathToLocation"> Шлях до місця розташування ярлика</param>
        public static void Creator(string pathToFile, string pathToLocation) 
        {
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                var lnk = shell.CreateShortcut(pathToLocation);
                try
                {
                    lnk.TargetPath = pathToFile;
                    lnk.IconLocation = "shell32.dll, 1";
                    lnk.Save();
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }

        }
    }
}
