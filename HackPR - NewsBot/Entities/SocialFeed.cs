using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class SocialFeed
    {
        public string title { get; set; }
        public string path { get; set; }

        public override string ToString()
        {
            return $"{title}\n{path}\n";
        }
    }
}