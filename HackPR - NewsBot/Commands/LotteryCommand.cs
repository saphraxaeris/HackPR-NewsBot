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
    public class LotteryCommand : Command
    {
        private string key;
        public LotteryCommand(string key)
        {
            this.key = key;
        }
        public override string Execute(string message)
        {
            var client = new HttpClient();
            var queryString = "https://gfrmservices.azure-api.net/end/v3/lottery";

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var response = client.GetAsync(queryString).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<LotteryArticles>(json);

                if (message.Replace(".", "").Equals("lottery"))
                {
                    return result.ToString();
                }
                else if(message.Contains("traditional"))
                {
                    result.lottery.Tradicional();
                }
                else if (message.Contains("loto"))
                {
                    result.lottery.Loto();
                }
                else if (message.Contains("revancha"))
                {
                    result.lottery.Revancha();
                }
                else if (message.Contains("pega 2") || message.Contains("pega2"))
                {
                    result.lottery.Pega2();
                }
                else if (message.Contains("pega 3") || message.Contains("pega3"))
                {
                    result.lottery.Pega3();
                }
                else if (message.Contains("pega 4") || message.Contains("pega4"))
                {
                    result.lottery.Pega4();
                }
                else if (message.Contains("ivu loto") || message.Contains("ivuloto"))
                {
                    result.lottery.IvuLoto();
                }
            }
            return "Error occurred while executing command.\n";
        }

        public override string ToString()
        {
            return "LotteryCommand: Gives a list of the lottery results.\nExample: Lottery {tag} Results";
        }

        public override bool Validate(string message)
        {
            message = message.ToLower();
            var check1 = message.Equals("lottery");

            var check2 = message.Equals("lottery tradicional");
            var check3 = message.Equals("lottery revancha");
            var check4 = message.Equals("lottery loto");
            var check5 = message.Equals("lottery pega2") || message.Equals("lottery pega 2");
            var check6 = message.Equals("lottery pega3") || message.Equals("lottery pega 3");
            var check7 = message.Equals("lottery pega4") || message.Equals("lottery pega 4");
            var check8 = message.Equals("lottery ivu loto");
            var check9 = message.Equals("lottery ivuloto");

            var check10 = message.Equals("tradicional lottery");
            var check11 = message.Equals("revancha lottery");
            var check12 = message.Equals("loto lottery");
            var check13 = message.Equals("pega2 lottery");
            var check14 = message.Equals("pega3 lottery");
            var check15 = message.Equals("pega4 lottery");
            var check16 = message.Equals("ivu loto lottery");
            var check17 = message.Equals("ivuloto lottery");

            var check18 = message.Equals("tradicional");
            var check19 = message.Equals("revancha");
            var check20 = message.Equals("loto");
            var check21 = message.Equals("pega2");
            var check22 = message.Equals("pega3");
            var check23 = message.Equals("pega4");
            var check24 = message.Equals("ivu loto");
            var check25 = message.Equals("ivuloto");

            if (check1 || check2 || check3 || check4 || check5 || check6 || check7 || check8 || check9 || check10 || check11 || check12 || check13 || check14 || check15 || check16 || check17 || check18 || check19 || check20 || check21 || check22 || check23 || check24 || check25)
            {
                return true;
            }
            return false;
        }
    }
}