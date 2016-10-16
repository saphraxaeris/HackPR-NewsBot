using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackPR___NewsBot.Entities
{
    public class News
    {
        public string url { get; set; }
        public string title { get; set; }
        public string[] body { get; set; }

        public override string ToString()
        {
            return $"{title}{General.NewLine()}http://www.elnuevodia.com{url}{General.NewLine()}";
        }
    }
}
