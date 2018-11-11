#region Using directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Newtonsoft.Json;
using SimpleInjector;
#endregion

namespace TurtleEscape
{
    class Program
    {
        private static Container container;

        static void Main( string[] args )
        {
            Bootstrap();

            Parser.Default.ParseArguments<Options>( args )
                .WithParsed( options => RunGame( options ) )
                .WithNotParsed( errors => HandleErrors( errors ) );
        }

        private static void Bootstrap()
        {
            container = new Container();

            container.RegisterSingleton<ILogger, Logger>();

            container.Verify();
        }

        private static void RunGame( Options options )
        {
            var logger = container.GetInstance<ILogger>();

            var directory = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location );

            var gameSettingsFile = Path.Combine( directory, options.GameSetings );
            var sequencesFile = Path.Combine( directory, options.Moves );

            if ( !File.Exists( gameSettingsFile ) )
            {
                logger.Danger( "Game settings file does not exists." );
                return;
            }

            if ( !File.Exists( sequencesFile ) )
            {
                logger.Danger( "Sequences file does not exists." );
                return;
            }

            var gameSettings = JsonConvert.DeserializeObject<GameSettings>( File.ReadAllText( gameSettingsFile ) );
            var sequences = JsonConvert.DeserializeObject<Sequence[]>( File.ReadAllText( sequencesFile ) );

            var board = container.GetInstance<Board>();

            board.Init( gameSettings );

            board.Run( sequences );
        }

        private static void HandleErrors( IEnumerable<Error> errors )
        {
            var logger = container.GetInstance<ILogger>();

            foreach ( var error in errors )
                logger.Danger( error.ToString() );
        }
    }
}
