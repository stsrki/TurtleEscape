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
        #region Members

        private readonly Board board;

        #endregion

        #region Constructors

        public Collision( Board board )
        {
            this.board = board;
        }

        #endregion

        #region Methods

        public GameObject Check( GameObject current )
        {
            return board.GameObjects.FirstOrDefault( p => !object.ReferenceEquals( p, current ) && p.Position == current.Position );
        }

        #endregion
    }
}
