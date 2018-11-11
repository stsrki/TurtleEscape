#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    /// <summary>
    /// Defines the position of game object on the board.
    /// </summary>
    public struct Position
    {
        #region Constructors

        public Position( int x, int y )
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Operators

        public override bool Equals( object obj )
        {
            if ( !( obj is Position ) )
                return false;

            var mys = (Position)obj;

            return X == mys.X && Y == mys.Y;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static bool operator ==( Position p1, Position p2 )
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=( Position p1, Position p2 )
        {
            return p1.X != p2.X || p1.Y != p2.Y;
        }

        public static Position operator +( Position p1, Position p2 )
        {
            p1.X += p2.X;
            p1.Y += p2.Y;
            return p1;
        }

        public static Position operator -( Position p1, Position p2 )
        {
            p1.X -= p2.X;
            p1.Y -= p2.Y;
            return p1;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Offset on the X cordianate starting from the top left field.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Offset on the Y cordianate starting from the top left field.
        /// </summary>
        public int Y { get; set; }

        #endregion
    }
}
