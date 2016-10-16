using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class Feed
    {
        public SocialFeed[] stories { get; set; }
        public override string ToString()
        {
            int index = 1;
            var result = "";
            foreach (var story in stories)
            {
                result += $"{index++}. {story.ToString()}\n";
            }
            return result;
        }
    }
}