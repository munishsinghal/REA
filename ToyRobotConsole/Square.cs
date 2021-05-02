using System;
using System.Collections.Generic;

namespace ToyRobot.Console
{
    /// <summary>The User Interface is responsible for all interactions with the user.</summary>
    public class Square
    {
        /// <summary>Private instance variable to hold self singleton object.</summary>
        /// <value>Hold value of self as singleton </value>
        private static Square _instance;

        /// <summary>Public read-only property to expose the game's map.</summary>
        /// <value>Gets the value of the game's map</value>
        public List<Location> Map { get; }

        protected Square()
        {
        }

        /// <summary>
        /// Singleton implementation so that no more than one object created for this class
        /// </summary>
        /// <param name="dim_x"></param>
        /// <param name="dim_y"></param>
        /// <returns></returns>
        public static Square Instance(int dim_x, int dim_y)
        {
            if (_instance == null)
            {
                _instance = new Square(dim_x, dim_y);
            }
            return _instance;
        }

        /// <summary>
        /// constructor function to execute & define a list with location that define available locations for square in robot game
        /// </summary>
        /// <param name="dim_x"></param>
        /// <param name="dim_y"></param>
        protected Square(int dim_x, int dim_y)
        {
            Map = new List<Location>();
            for (int y = dim_y - 1; y >= 0; y--)
            {
                for (int x = 0; x < dim_x; x++)
                {
                    Map.Add(new Location(x, y));
                }
            }
        }


    }
}