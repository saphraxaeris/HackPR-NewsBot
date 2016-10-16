using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class Horoscopes
    {
        public string sign { get; set; }
        public string id { get; set; }
        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }
        public Horoscope horoscope { get; set; }

        public override string ToString()
        {
            return $"Here is your result!{General.NewLine()}{sign} ({from_date.ToShortDateString()} - {to_date.ToShortDateString()}){General.NewLine()}{horoscope.ToString()}{General.NewLine()}";
        }
    }
}