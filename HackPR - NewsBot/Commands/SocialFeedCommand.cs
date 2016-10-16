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
    public class SocialFeedCommand : Command
    {
        private string key;
        public SocialFeedCommand(string key)
        {
            this.key = key;
        }
        public override string Execute(string message)
        {
            var client = new HttpClient();
            var queryString = "https://gfrmservices.azure-api.net/end/v3/social/feed";

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var response = client.GetAsync(queryString).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<SocialFeedArticles>(json);
                return result.ToString();
            }
            return $"Error occurred while executing command.{General.NewLine()}";
        }

        public override string ToString()
        {
            return $"Social Feed: Gives the most shared information on Social.{General.NewLine()}Example: Social Feed";

        }

        public override bool Validate(string message)
        {
            message = message.ToLower();
            var check1 = message.Equals("social feed");

            return check1;
        }
    }
}