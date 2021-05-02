using System;
using System.Collections.Generic;

namespace ToyRobot.Console
{
    /// <summary>The Game class manages the game world.</summary>
    public class Game
    {

        /// <summary>Public read-only property to expose the robot.</summary>
        /// <value>Gets the value of the game's robot</value>
        public Square Square { get; }

        /// <summary>Public read-only property to expose the robot.</summary>
        /// <value>Gets the value of the game's robot</value>
        public Robot Robot { get; }

        /// <summary>Private field for the game's playing state.</summary>
        private bool _playing;


        /// <summary>Private field for the game's command processor.</summary>
        private CommandProcessor _commandProcessor;

        /// <summary>Public read-only property to expose the user interface.</summary>
        /// <value>Gets the value of the game's user interface</value>
        public UserInterface UI { get; }

        /// <summary>Game constructor</summary>
        /// <param name="dim_x">An int parameter for the width of the map</param>
        /// <param name="dim_y">An int parameter for the height of the map</param>
        public Game(int dim_x, int dim_y)
        {
            Square = Square.Instance(dim_x, dim_y);
            Robot = new Robot(this);
            _commandProcessor = new CommandProcessor(this);
            UI = UserInterface.Instance();
        }


        /// <summary>Begins the game and manages the game loop</summary>
        public void Start()
        {
            UI.PrintMessage("Welcome to the REA Toy Robot!", true);
            UI.PrintMessage("Below are the actions, you can perform" +
                "\n PLACE X,Y,F (example: PLACE 0,0,NORTH)" +
                "\n MOVE" +
                "\n LEFT" +
                "\n RIGHT" +
                "\n REPORT" +
                "\n EXIT"
                , false);
            _playing = true;
            while (_playing)
            {
                string command = UI.AskUser("What would you like to do? ::: ").ToUpper();
                _commandProcessor.Execute(command);
            }
            UI.PrintMessage("Thanks for playing!", true);
        }

        /// <summary>Ends the game</summary>
        public void Stop()
        {
            _playing = false;
        }
    }
}