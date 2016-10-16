using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class ivu_loto
    {
        public DateTime date { get; set; }
        public ivu_loto_detail[] ivulotodetail { get; set; }

        public override string ToString()
        {
            var result = $"Date: {date.ToShortDateString()}\n";
            foreach (var detail in ivulotodetail)
            {
                result += $"{detail.ToString()}\n";
            }
            return result;
        }
    }
}