using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Social Feed: Gives the most shared information on Social.\nExample: Social Feed";

        }

        public override bool Validate(string message)
        {
            message = message.ToLower();
            var check1 = message.Equals("social feed");

            return check1;
        }
    }
}