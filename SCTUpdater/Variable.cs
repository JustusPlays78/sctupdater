﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCTUpdater
{
    public class Paths
    {
        public string? SctPath { get; set; }
        public string? ConfigPath { get; set; }
        public string? CredentialsPath { get; set; }
        public string? CustomJsonPath { get; set; }
        public string? CustonJsonPathwjson { get; set; }
    }

    public class Variable
    {
        public static Paths Mainpath = new Paths();
        public static Credentials MainCredentials = new Credentials();
    }

    public class Credentials
    {
        public string Name { get; set; }
        public long Cid { get; set; }
        public string Password { get; set; }
        public string Cpdlc { get; set; }
    }

    public class CustomJsonVariables
    {
        public List<Setting> Settings { get; set; }
    }

    public class Setting
    {
        public string FileName { get; set;}
        public string OldContent { get; set;}
        public string NewContent { get; set;}

    }
}
