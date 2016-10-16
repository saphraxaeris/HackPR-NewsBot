using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "LotteryCommand: Gives a list of the lottery results.\nExample: Lottery Results";
        }

        public override bool Validate(string message)
        {
            message = message.ToLower();
            var check1 = message.StartsWith("lottery");
            return check1;
        }
    }
}