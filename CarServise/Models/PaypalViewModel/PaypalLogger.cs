using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace CarServise.Models.PaypalViewModel
{
    public class PaypalLogger
    {
        public static string LogDirectoryPath = Environment.CurrentDirectory;
        public static void Log(string lines)
        {
            try
            {
                StreamWriter stream = new StreamWriter(LogDirectoryPath+"\\PaypalError.log", true);
                stream.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"+"---->"+lines));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
