using HackPR___NewsBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace HackPR___NewsBot.Commands
{
    public class NewsCommand : Command
    {
        private string key;
        public NewsCommand(string key)
        {
            this.key = key;
        }

        public override string Execute(string message)
        {
            message = message.Replace("news in", "");
            message = message.Replace("news about", "");
            message = message.Replace("latest news", "");
            message = message.Replace("latest ", "");
            message = message.Replace(" news", "");
            var tags = message.Replace(", ", " ").Replace(" ", ",");

            var client = new HttpClient();
            var queryString = "https://gfrmservices.azure-api.net/end/v3/news/?limit=0&page=1&&tags=" + tags;

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var response = client.GetAsync(queryString).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<NewsArticles>(json);
                return result.ToString();
            }
            return $"Error occurred while executing command.{General.NewLine()}";
        }

        public override string ToString()
        {
            return $"News: Returns a list of top ten news.{General.NewLine()}Example: News about {{tags}}";
        }

        public override bool Validate(string message)
        {
            message = message.ToLower();
            var check1 = message.StartsWith("news in");
            var check2 = message.StartsWith("news about");
            var check3 = message.StartsWith("latest news");
            var check4 = message.StartsWith("latest") && message.EndsWith("news");
            if (check1 || check2 || check3 || check4)
            {
                return true;
            }
            return false;
        }
    }
}