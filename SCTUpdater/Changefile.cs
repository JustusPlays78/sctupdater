using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SCTUpdater
{
    internal class Changefile
    {
        private static String path;

        public static void startbutton(Boolean cidname, Boolean password)
        {

        }

        private static void readtxt()
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                string txt = reader.ReadLine();

            }
            catch
            {
                Console.Write("Execption");
            }



        } 
    }
}
