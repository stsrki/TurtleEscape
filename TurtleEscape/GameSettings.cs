#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    class GameSettings : IGameSettings
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Turtle Turtle { get; set; }

        public Mine[] Mines { get; set; }

        public Exit Exit { get; set; }
    }
}
