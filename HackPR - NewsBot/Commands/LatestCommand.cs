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
    public class LatestCommand : Command
    {
        private string key;
        public LatestCommand(string key)
        {
            this.key = key;
        }
        public override string Execute(string message)
        {
            var client = new HttpClient();
            var queryString = "https://gfrmservices.azure-api.net/end/v3/news/?limit=0&page=1&&tags=" + tags;

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var response = client.GetAsync(queryString).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<LatestArticles>(json);
                return result.ToString();
            }
            return "Error occurred while executing command.\n";
        }

        public override string ToString()
        {
            return "Latest: Gives the latest everything.\nExample: Latest everything";
        }

        public override bool Validate(string message)
        {
            message = message.ToLower();
            var check1 = message.Equals("latest everything");

            return check1;

        }
    }
}