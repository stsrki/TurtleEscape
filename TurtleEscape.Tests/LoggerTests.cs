using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TurtleEscape.Tests
{
    [TestClass]
    public class LoggerTests : TestBase
    {
        [TestMethod]
        public void Rotate_FromNorthOneTime_ExpectEast()
        {
            var board = MakeBoard();
            board.Turtle.Rotation = Rotation.North;

            board.Run(
                new Sequence( SequenceType.Rotate, 1 ) );

            logger.Received().Info( $"Rotated {Rotation.East}!" );
        }

        [TestMethod]
        public void Rotate_FromEastTwoTimes_ExpectedWest()
        {
            var board = MakeBoard();
            board.Turtle.Rotation = Rotation.East;

            board.Run(
                new Sequence( SequenceType.Rotate, 2 ) );

            logger.Received().Info( $"Rotated {Rotation.West}!" );
        }

        [TestMethod]
        public void Escape_ExpectedSuccess()
        {
            var board = MakeBoard();

            board.Run(
                new Sequence( SequenceType.Move, 1 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 2 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 2 ),
                new Sequence( SequenceType.Rotate, 3 ),
                new Sequence( SequenceType.Move, 2 ) );

            logger.Received().Success( "Little turtle has escaped! :)" );
        }

        [TestMethod]
        public void Escape_ExpectedDanger()
        {
            var board = MakeBoard();

            board.Run(
                new Sequence( SequenceType.Move, 1 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 2 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 2 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 2 ) );

            logger.Received().Danger( "Still in danger!" );
        }
    }
}
