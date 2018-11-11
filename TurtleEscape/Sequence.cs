#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    public class Sequence
    {
        public Sequence( SequenceType type, int times )
        {
            Type = type;
            Times = times;
        }

        /// <summary>
        /// Sequence type.
        /// </summary>
        public SequenceType Type { get; set; }

        /// <summary>
        /// Number of times to repeat the sequence.
        /// </summary>
        public int Times { get; set; }
    }

    public enum SequenceType
    {
        Move,
        Rotate,
    }
}
