using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Opinions: Gives a list of the top ten Opinions Article.\nExample: Opinions of {tags}";
        }

        public override bool Validate(string message)
        {
            message = message.ToLower();
            var check1 = message.StartsWith("opinions");
            var check2 = message.StartsWith("opinion");
            
            if (check1 || check2)
            {
                return true;
            }

            return false;
        }
    }
}