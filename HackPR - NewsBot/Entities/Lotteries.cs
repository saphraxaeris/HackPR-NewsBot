using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackPR___NewsBot.Entities
{
    public class Lotteries
    {
        public Lottery[] tradicional { get; set; }
        public Lottery[] loto { get; set; }
        public Lottery[] revancha { get; set; }
        public Pega[] pega2 { get; set; }
        public Pega[] pega3 { get; set; }
        public Pega[] pega4 { get; set; }
        public ivu_loto[] ivu_loto { get; set; }

        public string Tradicional()
        {
            var result = $"Traditional:{General.NewLine()}";
            foreach (var lottery in tradicional)
            {
                result += lottery.ToString() + General.NewLine();
            }
            return result;
        }

        public string Loto()
        {
            var result = $"Loto:{General.NewLine()}";
            foreach (var lottery in loto)
            {
                result += lottery.ToString() + General.NewLine();
            }
            return result;
        }

        public string Revancha()
        {
            var result = $"Revancha:{General.NewLine()}";
            foreach (var lottery in revancha)
            {
                result += lottery.ToString() + $"{General.NewLine()}";
            }
            return result;
        }

        public string Pega2()
        {
            var result = $"Pega 2:{General.NewLine()}";
            foreach (var pega in pega2)
            {
                result += pega.ToString() + $"{General.NewLine()}";
            }
            return result;
        }

        public string Pega3()
        {
            var result = $"Pega 3:{General.NewLine()}";
            foreach (var pega in pega3)
            {
                result += pega.ToString() + $"{General.NewLine()}";
            }
            return result;
        }

        public string Pega4()
        {
            var result = $"Pega 4:{General.NewLine()}";
            foreach (var pega in pega4)
            {
                result += pega.ToString() + $"{General.NewLine()}";
            }
            return result;
        }

        public string IvuLoto()
        {
            var result = $"Ivu Loto:{General.NewLine()}";
            foreach (var ivu in ivu_loto)
            {
                result += ivu.ToString() + $"{General.NewLine()}";
            }
            return result;
        }

        public override string ToString()
        {
            return Tradicional() + Loto() + Revancha() + Pega2() + Pega3() + Pega4() + IvuLoto() + General.NewLine();
        }
    }
}