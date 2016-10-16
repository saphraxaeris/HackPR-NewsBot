using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml;
using HackPR___NewsBot.Commands;
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
                new NewsCommand(Key),
                //new TestCommand(Key)
            };

        //public MessagesController()
        //{
        //    _commands = new List<Command>
        //    {
        //        new HoroscopesCommand(Key),
        //        new LatestCommand(Key),
        //        new LotteryCommand(Key),
        //        new OpinionsCommand(Key),
        //        new SocialFeedCommand(Key),
        //        new NewsCommand(Key),
        //        //new TestCommand(Key)
        //    };
        //}

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            var message = activity.Text.ToLower();
            var answer = "Could not process your input.";
            if (GenericMessages(message) != null)
            {
                answer = GenericMessages(message);
                return await Response(activity, answer);
            }
            if (IsHelp(message))
            {
                answer = Help();
                return await Response(activity, answer);
            }
            foreach (var command in _commands)
            {
                if (command.Validate(message))
                {
                    answer = command.Execute(message);
                    return await Response(activity, answer);
                }
            }
            return await Response(activity, answer);
        }

        private string GenericMessages(string message)
        {
            message = message.ToLower().Replace(".", "");
            message = message.Replace("!", "");
            message = message.Replace("?", "");
            message = message.Replace(",", "");

            if (message.Equals("hi") || message.Equals("hello"))
            {
                return "Hello!" + General.NewLine();
            }
            else if (message.Equals("who are you"))
            {
                return "I am the El Nuevo Dia News Bot! I exist to provide you with up to date news anytime you need!" + General.NewLine();
            }
            else if (message.Equals("that's pretty cool"))
            {
                return "Thanks! I think you're pretty cool as well." + General.NewLine();
            }
            else if (message.Equals("can you do anything else"))
            {
                return "Not at the moment." + General.NewLine();
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
            var result = "I can do the following:" + General.NewLine();
            foreach (var command in _commands)
            {
                result += index + ". " + command.ToString() + General.NewLine();
                index++;
            }
            return result;
        }

        private bool IsHelp(string message)
        {
            if (message.ToLower().StartsWith("help") || message.ToLower().StartsWith("what can you do"))
            {
                return true;
            }
            return false;
        }

        private async Task<HttpResponseMessage> Response(Activity activity, string answer)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            var replyMessage = activity.CreateReply();
            replyMessage.Recipient = activity.From;
            replyMessage.Type = ActivityTypes.Message;
            replyMessage.Text = answer;
            await connector.Conversations.ReplyToActivityAsync(replyMessage);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing that the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}