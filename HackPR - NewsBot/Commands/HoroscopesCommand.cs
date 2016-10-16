using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using HackPR___NewsBot.Entities;
using Newtonsoft.Json;

namespace HackPR___NewsBot.Commands
{
    public class HoroscopesCommand : Command
    {
        private string key;

        public HoroscopesCommand(string key)
        {
            this.key = key;
        }
        public override string Execute(string message)
        {
            var client = new HttpClient();
            var queryString = "https://gfrmservices.azure-api.net/end/v3/horoscope";

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var response = client.GetAsync(queryString).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<HoroscopeArticles>(json);

                if (message.Equals("horoscope") || message.Equals("horoscopes"))
                {
                    return result.ToString();
                }
                else if (message.Contains("aquarius"))
                {
                    return result.horoscopes[0].ToString();
                }
                else if (message.Contains("aries"))
                {
                    return result.horoscopes[1].ToString();
                }
                else if (message.Contains("taurus"))
                {
                    return result.horoscopes[2].ToString();
                }
                else if (message.Contains("gemini"))
                {
                    return result.horoscopes[3].ToString();
                }
                else if (message.Contains("cancer"))
                {
                    return result.horoscopes[4].ToString();
                }
                else if (message.Contains("leo"))
                {
                    return result.horoscopes[5].ToString();
                }
                else if (message.Contains("virgo"))
                {
                    return result.horoscopes[6].ToString();
                }
                else if (message.Contains("libra"))
                {
                    return result.horoscopes[7].ToString();
                }
                else if (message.Contains("escorpio"))
                {
                    return result.horoscopes[8].ToString();
                }
                else if (message.Contains("sagittarius"))
                {
                    return result.horoscopes[9].ToString();
                }
                else if (message.Contains("capricorn"))
                {
                    return result.horoscopes[10].ToString();
                }
                else if (message.Contains("pisces"))
                {
                    return result.horoscopes[11].ToString();
                }
                return result.ToString();
            }
            return "Error occurred while executing command.\n";
        }

        public override string ToString()
        {
            return "Horoscopes: Gives the horoscope reading of the day.\nExample: Horoscope of {sign}";
        }

        public override bool Validate(string message)
        {
            message = message.ToLower();
            var check1 = message.StartsWith("horoscopes");
            var check2 = message.Equals("aquarius");
            var check3 = message.Equals("aries");
            var check4 = message.Equals("taurus");
            var check5 = message.Equals("gemini");
            var check6 = message.Equals("cancer");
            var check7 = message.Equals("leo");
            var check8 = message.Equals("virgo");
            var check9 = message.Equals("libra");
            var check10= message.Equals("escorpio");
            var check11 = message.Equals("sagittarius");
            var check12 = message.Equals("capricorn");
            var check13 = message.Equals("pisces");
            var check14 = message.Contains("horoscope") && message.Contains("aquarius") && message.Length == 18;
            var check15 = message.Contains("horoscope") && message.Contains("aries") && message.Length == 14;
            var check16 = message.Contains("horoscope") && message.Contains("taurus") && message.Length == 15;
            var check17 = message.Contains("horoscope") && message.Contains("gemini") && message.Length == 15;
            var check18 = message.Contains("horoscope") && message.Contains("cancer") && message.Length == 15;
            var check19 = message.Contains("horoscope") && message.Contains("leo") && message.Length == 12;
            var check20 = message.Contains("horoscope") && message.Contains("virgo") && message.Length == 14;
            var check21 = message.Contains("horoscope") && message.Contains("libra") && message.Length == 14;
            var check22 = message.Contains("horoscope") && message.Contains("escorpio") && message.Length == 17;
            var check23 = message.Contains("horoscope") && message.Contains("sagittarius") && message.Length == 20;
            var check24 = message.Contains("horoscope") && message.Contains("capricorn") && message.Length == 18;
            var check25 = message.Contains("horoscope") && message.Contains("pisces") && message.Length == 15;



            if (check1 || check2 || check3 || check4 || check5 || check6 || check7 || check8 || check9 || check10 || check11 || check12 || check13 || check14 || check15 ||check16 ||check17 || check18 || check19 || check20 || check21 || check22 || check23 || check24 || check25)
            {
                return true;
            }
            return false;
        }
    }
}