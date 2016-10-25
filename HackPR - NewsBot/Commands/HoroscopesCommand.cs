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
        public override string Execute(string parameter)
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

                if (string.IsNullOrEmpty(parameter))
                {
                    return result.ToString();
                }
                switch (parameter)
                {
                    case "aries":
                        return result.horoscopes.aries.ToString();
                    case "taurus":
                        return result.horoscopes.tauro.ToString();
                    case "gemini":
                        return result.horoscopes.geminis.ToString();
                    case "cancer":
                        return result.horoscopes.cancer.ToString();
                    case "leo":
                        return result.horoscopes.leo.ToString();
                    case "virgo":
                        return result.horoscopes.virgo.ToString();
                    case "libro":
                        return result.horoscopes.libra.ToString();
                    case "scorpio":
                        return result.horoscopes.escorpio.ToString();
                    case "sagittarius":
                        return result.horoscopes.sagitario.ToString();
                    case "capricorn":
                        return result.horoscopes.capricornio.ToString();
                    case "aquarius":
                        return result.horoscopes.acuario.ToString();
                    case "pisces":
                        return result.horoscopes.piscis.ToString();
                    default:
                        return $"Error occurred while executing command.{General.NewLine()}";
                }
            }
            return $"Error occurred while executing command.{General.NewLine()}";
        }

        public override string ToString()
        {
            return $"Horoscopes: Gives the horoscope reading of the day.{General.NewLine()}Example: Horoscope of {{sign}}";
        }

        public override bool Validate(string intent)
        {
            return intent.Equals("Horoscope");
        }

        public override string ExtractParameter(LUIS_Result result)
        {
            if (result.entities == null)
            {
                return null;
            }

            var index = -1;
            var maxScore = 0.0;
            for (var i = 0; i < result.entities.Length; i++)
            {
                if (!result.entities[i].type.Equals("ZodiacSign") || !(result.entities[i].score * 100 > maxScore))
                    continue;
                maxScore = result.entities[i].score * 100;
                index = i;
            }

            return index == -1 ? null : result.entities[index].entity.Replace(" ", "");
        }
    }
}