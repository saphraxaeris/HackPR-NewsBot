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

    public class LatestArticles
    {
        public News[] latest { get; set; }

        public override string ToString()
        {
            var index = 1;
            return latest.Aggregate("", (current, news) => current + (index++ + ". " + news.ToString() + "\n"));
        }
    }

    public class HoroscopeArticles
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
                      capricornio.ToString() + acuario.ToString() + piscis.ToString();
            return result;
        }
    }

    public class OpinionArticles
    {
        public News[] opinion { get; set; }

        public override string ToString()
        {
            var index = 1;
            return opinion.Aggregate("", (current, news) => current + (index++ + ". " + news.ToString() + "\n"));
        }
    }

    public class LotteryArticles
    {
        public Lotteries lottery { get; set; }

        public override string ToString()
        {
            return lottery.ToString();
        }
    }


    public class SocialFeedArticles
    {
        public Feed feed { get; set; }

        public override string ToString()
        {
            return feed.ToString() + "\n";
        }
    }
}
