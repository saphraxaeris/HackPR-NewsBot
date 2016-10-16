using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class ivu_loto_detail
    {
        public string winner { get; set; }
        public string city { get; set; }
        public string commerce { get; set; }
        public string award { get; set; }

        public override string ToString()
        {
            return $"Winner: {winner} - City: {city} - Commerce: {commerce} - Award: {award}{General.NewLine()}";
        }
    }
}