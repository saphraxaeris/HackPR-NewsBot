using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class Lottery
    {
        public string date { get; set; }
        public string[] winners { get; set; }

        public string ToString(string name)
        {
            var result = name + ":\n";
            foreach(var winner in winners) {
                result += winner + "\n";
            }
            return name + ":\n";
        }
    }
    
}