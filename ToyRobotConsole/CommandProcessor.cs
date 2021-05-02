using System;
using System.Linq;
using System.Collections.Generic;

namespace ToyRobot.Console
{
    /// <summary>
    /// The CommandProcessor class takes a command string, validates that it contains known commands
    /// and manages propagation of commands to the correct game elements.
    /// </summary>
    public class CommandProcessor
    {
        /// <summary>Private field for game.</summary>
        private Game _game;

        /// <summary>Command Processor constructor</summary>
        /// <param name="game">A game parameter to manage command propagation</param>
        public CommandProcessor(Game game)
        {
            _game = game;
        }


        /// <summary>Public read-only property to expose the robot.</summary>
        /// <value>Gets the value of the game's robot</value>
        public Robot Robot { get; }

        /// <summary>Provides a list of suggestions for known commands</summary>
        /// <returns>A string representation of a list of known commands</returns>
        private string Help()
        {
            return "I'm not sure how to process that command. Try one of these:\n" +
                "\n PLACE X,Y,F (example: PLACE 0,0,NORTH)" +
                "\n MOVE" +
                "\n LEFT" +
                "\n RIGHT" +
                "\n REPORT" +
                "\n EXIT";
        }



        /// <summary>Validates the command string and propagates to appropriate game object</summary>
        /// <param name="command">A string containing the command</param>
        public void Execute(string command)
        {
            string upperCommand = command.ToUpper();
            if (upperCommand.Contains("PLACE"))
                _game.Robot.Place(upperCommand);
            else
            {
                switch (upperCommand)
                {
                    case "MOVE":
                        _game.Robot.Move();
                        break;
                    case "LEFT":
                        _game.Robot.Rotate(Rotation.LEFT);
                        break;
                    case "RIGHT":
                        _game.Robot.Rotate(Rotation.RIGHT);
                        break;
                    case "REPORT":
                        _game.Robot.Report();
                        break;
                    case "EXIT":
                        _game.Stop();
                        break;
                    default:
                        _game.UI.PrintMessage(Help(), false);
                        break;
                }
            }
        }
    }
}