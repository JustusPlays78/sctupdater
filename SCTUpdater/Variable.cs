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
        public string Name { get; set; }
        public string Cid { get; set; }
        public string Password { get; set; }
        public string Cpdlc { get; set; }
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
        public string EdwwAppCtr { get; set; }
        public string EdbbAppCtr { get; set; }
        public string EduuCtr { get; set; }
        public string EdyyCtr { get; set; }
        public string EdwwTwr { get; set; }
        public string EdbbTwr { get; set; }
    }

    public class EDMMProfiles
    {
        public string Edmm { get; set; }
        public string Eduu { get; set; }
        public string TwrReal { get; set; }
    }
}
