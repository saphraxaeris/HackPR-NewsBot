using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class Pega
    {
        public string winner { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }

        public override string ToString()
        {
            return $"{date.ToShortDateString()} - Winner: {winner} - Type: {type}";
        }
    }
}