using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class Action
    {
        public bool triggered { get; set; }
        public string name { get; set; }
        public string parameters { get; set; }
    }
}