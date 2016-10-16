using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class HoroscopeData
    {
        public Horoscopes aries { get; set; }
        public Horoscopes tauro { get; set; }
        public Horoscopes geminis { get; set; }
        public Horoscopes cancer { get; set; }
        public Horoscopes leo { get; set; }
        public Horoscopes virgo { get; set; }
        public Horoscopes libra { get; set; }
        public Horoscopes escorpio { get; set; }
        public Horoscopes sagitario { get; set; }
        public Horoscopes capricornio { get; set; }
        public Horoscopes acuario { get; set; }
        public Horoscopes piscis { get; set; }

        public override string ToString()
        {
            string result = "";
            result += aries.ToString() + tauro.ToString() + geminis.ToString() + cancer.ToString() + leo.ToString() +
                      virgo.ToString() + libra.ToString() + escorpio.ToString() + sagitario.ToString() +
                      capricornio.ToString() + acuario.ToString() + piscis.ToString() + General.NewLine();
            return result;
        }
    }
}