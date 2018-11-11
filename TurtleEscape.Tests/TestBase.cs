#region Using directives
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
#endregion

namespace TurtleEscape.Tests
{
    public class TestBase
    {
        protected ILogger logger;

        [TestInitialize]
        public void Setup()
        {
            logger = Substitute.For<ILogger>();
        }

        [TestCleanup]
        public void Close()
        {
        }

        protected Turtle MakeTurtle( Position position, Rotation rotation = Rotation.North )
        {
            var board = MakeBoard();

            var turtle = new Turtle()
            {
                Position = position,
                Rotation = rotation
            };

            return turtle;
        }

        protected Board MakeBoard()
        {
            var gameSettings = MakeGameSettings();

            var board = new Board( logger );

            board.Init( gameSettings );

            return board;
        }

        IGameSettings MakeGameSettings()
        {
            var gameSettings = Substitute.For<IGameSettings>();

            gameSettings.Width.Returns( 5 );
            gameSettings.Height.Returns( 4 );

            gameSettings.Turtle.Returns( new Turtle
            {
                Position = new Position( 0, 1 ),
                Rotation = Rotation.North
            } );

            gameSettings.Mines.Returns( new Mine[]
            {
                new Mine { Position = new Position( 1, 1 ) },
                new Mine { Position = new Position( 3, 1 ) },
                new Mine { Position = new Position( 3, 3 ) }
            } );

            gameSettings.Exit.Returns( new Exit { Position = new Position( 4, 2 ) } );

            return gameSettings;
        }
    }
}
