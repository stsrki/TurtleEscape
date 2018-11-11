#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    public abstract class GameObject
    {
        /// <summary>
        /// Defines the game object position in the 2-dimensional coordinates
        /// </summary>
        public Position Position { get; set; }

        public virtual void Handle( ILogger logger, Turtle turtle )
        {
        }
    }
}
