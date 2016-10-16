namespace HackPR___NewsBot.Commands
{
    public abstract class Command
    {
        /// <summary>
        /// Executes a command with a given valid string.
        /// </summary>
        /// <param name="message">
        /// Message to parse and execute
        /// </param>
        /// <returns>
        /// Response message
        /// </returns>
        public abstract string Execute(string message);

        /// <summary>
        /// Validates if a given message if a valid command 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract bool Validate(string message);

        /// <summary>
        /// Structured string for easy readability.
        /// </summary>
        /// <returns>
        /// string
        /// </returns>
        public abstract override string ToString();
    }
}
