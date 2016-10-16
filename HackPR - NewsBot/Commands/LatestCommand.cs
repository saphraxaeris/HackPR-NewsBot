using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            throw new NotImplementedException();
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