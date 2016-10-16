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
            return articles.Aggregate("", (current, news) => current + (index++ + ". " + news.ToString() + General.NewLine()));
        }
    }

    public class LatestArticles
    {
        public News[] latest { get; set; }

        public override string ToString()
        {
            var index = 1;
            return latest.Aggregate("", (current, news) => current + (index++ + ". " + news.ToString() + General.NewLine()));
        }
    }

    public class HoroscopeArticles
    {
        public HoroscopeData horoscopes { get; set; }

        public override string ToString()
        {
            return horoscopes.ToString();
        }
    }

    public class OpinionArticles
    {
        public News[] opinion { get; set; }

        public override string ToString()
        {
            var index = 1;
            return opinion.Aggregate("", (current, news) => current + (index++ + ". " + news.ToString() + General.NewLine()));
        }
    }

    public class LotteryArticles
    {
        public Lotteries lottery { get; set; }

        public override string ToString()
        {
            return lottery.ToString() + General.NewLine();
        }
    }


    public class SocialFeedArticles
    {
        public Feed feed { get; set; }

        public override string ToString()
        {
            return feed.ToString() + General.NewLine();
        }
    }
}
