#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    public class Exit : GameObject
    {
        public override void Handle( ILogger logger, Turtle turtle )
        {
            logger.Info( "Exit reached!" );

            turtle.Exited = true;
        }
    }
}
