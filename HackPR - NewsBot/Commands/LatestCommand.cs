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
            var queryString = "https://gfrmservices.azure-api.net/end/v3/latest?limit=0";

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var response = client.GetAsync(queryString).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<LatestArticles>(json);
                return result.ToString();
            }
            return $"Error occurred while executing command.{General.NewLine()}";
        }

        public override string ToString()
        {
            return $"Latest: Gives the latest everything.{General.NewLine()}Example: Latest news about anything";
        }

        public override bool Validate(string message)
        {
            message = message.ToLower().Replace(".", "");
            var check1 = message.Equals("latest news about anything");

            return check1;

        }
    }
}