using HackPR___NewsBot.Entities;

namespace HackPR___NewsBot.Commands
{
    public abstract class Command
    {
        /// <summary>
        /// Executes a command with a given valid string as its parameter.
        /// </summary>
        /// <param name="parameter">
        /// Parameter for command
        /// </param>
        /// <returns>
        /// Response message
        /// </returns>
        public abstract string Execute(string parameter);

        /// <summary>
        /// Validates if a given intent name is specified command 
        /// </summary>
        /// <param name="intent"></param>
        /// <returns>
        /// bool
        /// </returns>
        public abstract bool Validate(string intent);

        /// <summary>
        /// Structured string for easy readability.
        /// </summary>
        /// <returns>
        /// string
        /// </returns>
        public abstract override string ToString();

        /// <summary>
        /// Extracts needed parameter from LUIS result
        /// </summary>
        /// <param name="result">
        /// LUIS_Result object
        /// </param>
        /// <returns>
        /// string
        /// </returns>
        public abstract string ExtractParameter(LUIS_Result result);
    }
}
