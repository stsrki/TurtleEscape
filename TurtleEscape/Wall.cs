#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    public class Wall : GameObject
    {
        public override void Handle( ILogger logger, Turtle turtle )
        {
            logger.Info( "Wall hit!" );

            turtle.Position -= turtle.LastMove;
        }
    }
}
