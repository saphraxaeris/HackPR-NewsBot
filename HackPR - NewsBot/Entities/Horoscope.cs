using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class Horoscope
    {
        public DateTime date { get; set; }
        public string sacred_word { get; set; }
        public int[] lucky_nubers { get; set; }
        public string text { get; set; }

        public override string ToString()
        {
            return "";
        }
    }
}