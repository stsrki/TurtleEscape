#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    public interface IGameSettings
    {
        /// <summary>
        /// Defines the board width.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Defines the board height.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Turtle game object.
        /// </summary>
        Turtle Turtle { get; }

        /// <summary>
        /// Defines the location of mines the board.
        /// </summary>
        Mine[] Mines { get; }

        /// <summary>
        /// Defines the exit location.
        /// </summary>
        Exit Exit { get; }
    }

    class GameSettings : IGameSettings
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Turtle Turtle { get; set; }

        public Mine[] Mines { get; set; }

        public Exit Exit { get; set; }
    }
}
