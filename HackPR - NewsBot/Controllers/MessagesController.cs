using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HackPR___NewsBot.Commands;
using HackPR___NewsBot.Entities;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace HackPR___NewsBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private const string Key = "449a24ecf4be482da238d3d38563b4a5";
        private readonly List<Command> _commands = new List<Command>
            {
                new HoroscopesCommand(Key),
                new LatestCommand(Key),
                new LotteryCommand(Key),
                new OpinionsCommand(Key),
                new SocialFeedCommand(Key),
                new NewsCommand(Key)
            };
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://api.projectoxford.ai/luis/v1/application?id=688a5065-6e27-4c0d-9198-ed050801be89&subscription-key=eaa861ea5af64c198352759a48425d41&")
        };

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                var message = activity.Text.ToLower();
                var answer = "Could not process your input.";
                if (GenericMessages(message) != null)
                {
                    answer = GenericMessages(message);
                    Response(activity, answer);
                }
                else if (IsHelp(message))
                {
                    answer = Help();
                    Response(activity, answer);
                }
                else
                {
                    var luisResponse = await _client.GetAsync($"q={message}&timezoneOffset=-4.0");
                    if (luisResponse.IsSuccessStatusCode)
                    {
                        var json = luisResponse.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<LUIS_Result>(json);
                        var index = -1;
                        var maxScore = 0.0;
                        for (var i = 0; i < result.intents.Length; i++)
                        {
                            if (!(result.intents[i].score*100 > maxScore)) continue;
                            maxScore = result.intents[i].score*100;
                            index = i;
                        }
                        if (result.intents[index].intent.Equals("None"))
                        {
                            answer = "I'm sorry, I couldn't interpret your message.";
                        }
                        else
                        {
                            foreach (var command in _commands)
                            {
                                if (!command.Validate(result.intents[index].intent)) continue;
                                var paramter = command.ExtractParameter(result);
                                answer = command.Execute(paramter);
                                break;
                            }
                        }
                        Response(activity, answer);
                    }
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private string GenericMessages(string message)
        {
            message = message.ToLower().Replace(".", "");
            message = message.Replace("!", "");
            message = message.Replace("?", "");
            message = message.Replace(",", "");

            if (message.Equals("hi") || message.Equals("hello"))
            {
                return "Hi! How are you?" + General.NewLine();
            }
            else if (message.Equals("good and you"))
            {
                return "I'm doing excellent! Thanks for asking!" + General.NewLine();
            }
            else if (message.Equals("who are you"))
            {
                return "I am the El Nuevo Dia News Bot! I exist to provide you with up to date news anytime you need!" + General.NewLine() + "For more information on what I can do just ask." + General.NewLine();
            }
            else if (message.Equals("that's pretty cool"))
            {
                return "Thanks! I think you're pretty cool as well." + General.NewLine();
            }
            else if (message.Equals("can you do anything else"))
            {
                return "Not at the moment. Hopefully soon I'll have a lot more commands to perform." + General.NewLine();
            }
            else if (message.Equals("let's try some commands"))
            {
                return "Ready for action!" + General.NewLine();
            }
            else
            {
                return null;
            }

        }

        private string Help()
        {
            var index = 1;
            var result = "I can currently perform the following commands:" + General.NewLine();
            foreach (var command in _commands)
            {
                result += index + ". " + command.ToString() + General.NewLine();
                index++;
            }
            return result;
        }

        private static bool IsHelp(string message)
        {
            if (message.ToLower().StartsWith("help") || message.ToLower().StartsWith("help me") || message.ToLower().StartsWith("what can you do"))
            {
                return true;
            }
            return false;
        }

        private static async void Response(Activity activity, string answer)
        {
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            var replyMessage = activity.CreateReply(answer);

            await connector.Conversations.ReplyToActivityAsync(replyMessage);
        }


        private static Activity HandleSystemMessage(Activity message)
        {
            switch (message.Type)
            {
                case ActivityTypes.DeleteUserData:
                    // Implement user deletion here
                    // If we handle user deletion, return a real message
                    break;
                case ActivityTypes.ConversationUpdate:
                    // Handle conversation state changes, like members being added and removed
                    // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                    // Not available in all channels
                    break;
                case ActivityTypes.ContactRelationUpdate:
                    // Handle add/remove from contact lists
                    // Activity.From + Activity.Action represent what happened
                    break;
                case ActivityTypes.Typing:
                    // Handle knowing that the user is typing
                    break;
                case ActivityTypes.Ping:
                    break;
            }

            return null;
        }
    }
}