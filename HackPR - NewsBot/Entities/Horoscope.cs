using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class Horoscope
    {
        public string date { get; set; }
        public string sacred_word { get; set; }
        public int[] lucky_nubers { get; set; }
        public string text { get; set; }

        public override string ToString()
        {
            string nums = "";
            if (lucky_nubers != null)
            {
                foreach (var num in lucky_nubers)
                {
                    nums += num + ", ";
                }
                nums = nums.Substring(0, nums.Length - 2);
            }
            else
            {
                nums = "N/A";
            }
            return $"Sacred Word: {sacred_word}{General.NewLine()}Lucky Numbers: {nums}{General.NewLine()}{text}{General.NewLine()}";
        }
    }
}