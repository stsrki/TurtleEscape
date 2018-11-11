#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    class Logger : ILogger
    {
        #region Methods

        public void Info( string message )
        {
            Write( message, Color.Normal );

            Console.Write( Environment.NewLine );
        }

        public void Success( string message )
        {
            Write( message, Color.Success );

            Console.Write( Environment.NewLine );
        }

        public void Danger( string message )
        {
            Write( message, Color.Error );

            Console.Write( Environment.NewLine );
        }

        private void Write( object value, Color color )
        {
            var foregroundColor = Console.ForegroundColor;

            Console.ForegroundColor = GetConsoleColor( color );

            Console.Write( value );

            Console.ForegroundColor = foregroundColor;
        }

        private ConsoleColor GetConsoleColor( Color color )
        {
            switch ( color )
            {
                case Color.Success:
                    return ConsoleColor.Cyan;
                case Color.Error:
                    return ConsoleColor.Red;
                case Color.Info:
                    return ConsoleColor.Green;
                default:
                    return ConsoleColor.White;
            }
        }

        #endregion
    }

    public enum Color
    {
        Normal,
        Success,
        Info,
        Error,
    }
}
