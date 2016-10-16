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
    public class OpinionsCommand : Command
    {
        private string key;
        public OpinionsCommand(string key)
        {
            this.key = key;
        }
        public override string Execute(string message)
        {
            message = message.Replace("opinions of", "");
            message = message.Replace("opinions", "");
            message = message.Replace("opinion", "");

            var tags = message.Replace(" ", ",");

            var client = new HttpClient();
            var queryString = "https://gfrmservices.azure-api.net/end/v3/Opinion?limit=0&page=1&tags=" + tags;

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var response = client.GetAsync(queryString).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<NewsArticles>(json);
                return result.ToString();
            }
            return "Error occurred while executing command.\n";
        }

        public override string ToString()
        {
            return "Opinions: Gives a list of the top ten Opinions Article.\nExample: Opinions of {tags}";
        }

        public override bool Validate(string message)
        {
            message = message.ToLower();
            var check1 = message.StartsWith("opinions of");
            var check2 = message.StartsWith("opinion");
            var check3 = message.EndsWith("opinions");
            var check4 = message.EndsWith("opinion");
            var check5 = message.StartsWith("opinions");

            if (check1 || check2 || check3 || check4 || check5)
            {
                return true;
            }

            return false;
        }
    }
}