using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackPR___NewsBot.Commands;

namespace HackPR___NewsBot
{
    public class GfrBot
    {
        private readonly List<Command> _commands;
        private const string Key = "449a24ecf4be482da238d3d38563b4a5";

        public GfrBot()
        {
            _commands = new List<Command>
            {
                new TestCommand(Key)
            };
        }

        public string Send(string message)
        {
            if (IsHelp(message))
            {
                return Help();
            }

            foreach (var command in _commands)
            {
                if (command.Validate(message))
                {
                    return command.Execute(message);
                }
            }
            return "Could not process your input.";
        }

        private string Help()
        {
            return _commands.Aggregate("I can do the following:\n", (current, command) => current + (command.ToString() + "\n"));
        }

        private bool IsHelp(string message)
        {
            if (message.ToLower().StartsWith("help") || message.ToLower().StartsWith("what can you do"))
            {
                return true;
            }
            return false;
        }
    }
}
