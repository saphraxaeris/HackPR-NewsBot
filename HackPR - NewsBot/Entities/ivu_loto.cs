using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class ivu_loto
    {
        public string date { get; set; }
        public ivu_loto_detail[] ivulotodetail { get; set; }

        public override string ToString()
        {
            var result = $"Date: {date.Substring(0, 10)}{General.NewLine()}";
            foreach (var detail in ivulotodetail)
            {
                result += $"{detail.ToString()}{General.NewLine()}";
            }
            return result;
        }
    }
}