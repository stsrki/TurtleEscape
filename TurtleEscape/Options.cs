#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
#endregion

namespace TurtleEscape
{
    class Options
    {
        [Option( 'g', Default = "game-settings.json", Required = true, HelpText = "Game settings file is not specified." )]
        public string GameSetings { get; set; }

        [Option( 'm', Default = "moves.json", Required = true, HelpText = "Moves file is not specified." )]
        public string Moves { get; set; }
    }
}
