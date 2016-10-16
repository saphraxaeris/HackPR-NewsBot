using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HackPR___NewsBot.Entities
{
    public class NewsArticles
    {
        public News[] articles { get; set; }

        public override string ToString()
        {
            var index = 1;
            return articles.Aggregate("", (current, news) => current + (index++ + ". " + news.ToString() + "\n"));
        }
    }
}
