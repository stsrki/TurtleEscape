using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurtleEscape.Tests
{
    [TestClass]
    public class RotationTests : TestBase
    {
        [TestMethod]
        public void Rotate_FromNorthOneTime_ExpectEast()
        {
            var board = MakeBoard();

            var expected = Rotation.East;

            board.Run(
                new Sequence( SequenceType.Rotate, 1 ) );

            Assert.AreEqual( expected, board.Turtle.Rotation );
        }

        [TestMethod]
        public void Rotate_FromNorthThreeTimes_ExpectWest()
        {
            var board = MakeBoard();

            var expected = Rotation.West;

            board.Run(
                new Sequence( SequenceType.Rotate, 3 ) );

            Assert.AreEqual( expected, board.Turtle.Rotation );


            var turtle = MakeTurtle( new Position( 0, 1 ), Rotation.North );
        }

        [TestMethod]
        public void Rotate_FromNorthFourTimes_ExpectNorth()
        {
            var board = MakeBoard();

            var expected = Rotation.North;

            board.Run(
                new Sequence( SequenceType.Rotate, 4 ) );

            Assert.AreEqual( expected, board.Turtle.Rotation );
        }

        [TestMethod]
        public void Rotate_FromWestFourTimes_ExpectWest()
        {
            var board = MakeBoard();
            board.Turtle.Rotation = Rotation.West;

            var expected = Rotation.West;

            board.Run(
                new Sequence( SequenceType.Rotate, 4 ) );

            Assert.AreEqual( expected, board.Turtle.Rotation );
        }

        [TestMethod]
        public void Rotate_FromEastTwoTimes_ExpectWest()
        {
            var board = MakeBoard();
            board.Turtle.Rotation = Rotation.East;

            var expected = Rotation.West;

            board.Run(
                new Sequence( SequenceType.Rotate, 2 ) );

            Assert.AreEqual( expected, board.Turtle.Rotation );
        }
    }
}
