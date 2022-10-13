using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCTUpdater
{
    //public class ConfigClass
    //{
    //    //public Paths[] Paths { get; set; }
    //    ////public Credentials Credentials { get; set; }
    //    //public EDGGProfiles[] EDGGProfiles { get; set; }
    //    //public EDWWProfiles[] EDWWProfiles { get; set; }
    //    //public EDMMProfiles[] EDMMProfiles { get; set; }
    //}

    public class Paths
    {
        public string SctPath { get; set; }
        public string ConfigPath { get; set; }
        public string CredentialsPath { get; set; }
    }

    public class Variable
    {
        public static Paths Mainpath = new Paths();
        public static Credentials MainCredentials = new Credentials();
        public static EDGGProfiles MainEdggProfile = new EDGGProfiles();
        public static EDWWProfiles MainEdwwProfile = new EDWWProfiles();
        public static EDMMProfiles MainEdmmProfile = new EDMMProfiles();
    }

    public class Credentials
    {
        public string Name { get; set; }
        public long Cid { get; set; }
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
