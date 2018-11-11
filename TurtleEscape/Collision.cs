#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    public class Collision
    {
        private readonly Board board;

        public Collision( Board board )
        {
            this.board = board;
        }

        public GameObject Check( GameObject current )
        {
            return board.GameObjects.FirstOrDefault( p => !object.ReferenceEquals( p, current ) && p.Position == current.Position );
        }
    }
}
