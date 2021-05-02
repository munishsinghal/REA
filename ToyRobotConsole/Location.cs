namespace ToyRobot.Console
{
    /// <summary>A Location is a single location containing an x and y coordinate.</summary>
    public class Location
    {
        /// <summary>Read-only property for x coordinate.</summary>
        /// <value>Gets the value of x coordinate</value>
        public int X { get; }

        /// <summary>Read-only property for y coordinate.</summary>
        /// <value>Gets the value of y coordinate</value>
        public int Y { get; }

        /// <summary>Location constructor</summary>
        /// <param name="x">An int parameter for the Location's x coordinate</param>
        /// <param name="y">An int parameter for the Location's y coordinate</param>
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}