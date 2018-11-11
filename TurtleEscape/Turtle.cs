#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    public class Turtle : GameObject
    {
        #region Members

        #endregion

        #region Constructors

        public Turtle()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Moves the turtle by one field.
        /// </summary>
        public void Move()
        {
            if ( Rotation == Rotation.North )
                LastMove = new Position( 0, -1 );
            else if ( Rotation == Rotation.East )
                LastMove = new Position( 1, 0 );
            else if ( Rotation == Rotation.South )
                LastMove = new Position( 0, 1 );
            else if ( Rotation == Rotation.West )
                LastMove = new Position( -1, 0 );

            Position += LastMove;
        }

        /// <summary>
        /// Rotate the turtle.
        /// </summary>
        /// <remarks>Rotation can only go clockwise.</remarks>
        public void Rotate()
        {
            int rotation = (int)Rotation;

            rotation++;

            if ( rotation > (int)Rotation.West )
                rotation = 0;

            Rotation = (Rotation)rotation;
        }

        #endregion

        #region Properties

        internal Position LastMove { get; set; }

        /// <summary>
        /// Defines the direction in which the turtle is looking.
        /// </summary>
        public Rotation Rotation { get; set; }

        /// <summary>
        /// Gets the turtle status.
        /// </summary>
        public bool Dead { get; internal set; }

        /// <summary>
        /// Gets the turte exit status.
        /// </summary>
        public bool Exited { get; internal set; }

        #endregion
    }
}
