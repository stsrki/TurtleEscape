#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    public interface ILogger
    {
        void Info( string message );

        void Danger( string message );

        void Success( string message );
    }
}
