using System;
using System.Collections.Generic;

namespace ToyRobot.Console
{
    /// <summary>The User Interface is responsible for all interactions with the user.</summary>
    public class UserInterface
    {
        /// <summary>Private instance variable to hold self singleton object.</summary>
        /// <value>Hold value of self as singleton </value>
        private static UserInterface _instance;
        protected UserInterface()
        {
        }

        /// <summary>
        /// singleton implementation which make sure no more than one object created for this class
        /// </summary>
        /// <returns></returns>
        public static UserInterface Instance()
        {
            if (_instance == null)
            {
                _instance = new UserInterface();
            }
            return _instance;
        }

        /// <summary>Asks the user a question and returns their response</summary>
        /// <param name="question">A string parameter containing the question for the user</param>
        /// <returns>A string value containing the user's response</returns>
        public string AskUser(string question)
        {
            System.Console.Write(question);
            return System.Console.ReadLine();
        }

        /// <summary>Prints a message to the console with a consistent format</summary>
        /// <param name="message">A string parameter containing the message to be printed to console</param>
        public void PrintMessage(string message, bool isDecorate)
        {
            if (isDecorate)
            {
                string formattedMessage = message.Replace("\n", "\n# ");
                System.Console.WriteLine("\n#######################");
                System.Console.WriteLine($"# {formattedMessage}");
                System.Console.WriteLine("#######################\n");
            }
            else
                System.Console.WriteLine(message);
        }

        

    }
}