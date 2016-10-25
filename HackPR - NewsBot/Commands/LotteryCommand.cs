using System.Net;
using System.Net.Http;
using HackPR___NewsBot.Entities;
using Newtonsoft.Json;

namespace HackPR___NewsBot.Commands
{
    public class LotteryCommand : Command
    {
        private readonly string _key;
        public LotteryCommand(string key)
        {
            _key = key;
        }
        public override string Execute(string parameter)
        {
            var client = new HttpClient();
            var queryString = "https://gfrmservices.azure-api.net/end/v3/lottery";

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);
            var response = client.GetAsync(queryString).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return $"Error occurred while executing command.{General.NewLine()}";
            var json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<LotteryArticles>(json);

            if (string.IsNullOrEmpty(parameter))
            {
                return result.ToString();
            }

            switch (parameter)
            {
                case "traditional":
                    return result.lottery.Tradicional();
                case "loto":
                    return result.lottery.Loto();
                case "revancha":
                    return result.lottery.Revancha();
                case "pega2":
                    return result.lottery.Pega2();
                case "pega3":
                    return result.lottery.Pega3();
                case "pega4":
                    return result.lottery.Pega4();
                case "ivuloto":
                    return result.lottery.IvuLoto();
                default:
                    return $"Error occurred while executing command.{General.NewLine()}";
            }
        }

        public override string ToString()
        {
            return $"Lottery: Gives a list of the lottery results.{General.NewLine()}Example: Lottery {{tag}}";
        }

        public override bool Validate(string intent)
        {
            return intent.Equals("Lottery");
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
                if (!result.entities[i].type.Equals("LotteryName") || !(result.entities[i].score*100 > maxScore))
                    continue;
                maxScore = result.entities[i].score*100;
                index = i;
            }

            return index == -1 ? null : result.entities[index].entity.Replace(" ", "");
        }
    }
}