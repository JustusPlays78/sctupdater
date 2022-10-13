using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCTUpdater
{
    public class Paths
    {
        public string GeneralPath { get; set; }
        public string ConfigPath { get; set; }
    }

    internal class Variable
    {
    }

    public class Credentials
    {
        public static string Name;
        public static string Cid;
        public static string Password;
        public static string Cpdlc;
    }
    public class EDGGProfiles
    {
        public string PheonixTwr { get; set; }
        public string Edgg { get; set; }
        public string Eduu { get; set; }
        public string EddfApn { get; set; }
        public string Alternate { get; set; }
        public string AlternateGrp { get; set; }
    }

    public class EDWWProfiles
    {
        public static string EdwwAppCtr;
        public static string EdbbAppCtr;
        public static string EduuCtr;
        public static string EdyyCtr;
        public static string EdwwTwr;
        public static string EdbbTwr;
    }

    public class EDMMProfiles
    {
        public static string Edmm;
        public static string Eduu;
        public static string TwrReal;
    }
}
