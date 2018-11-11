using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TurtleEscape.Tests
{
    [TestClass]
    public class DeadTests : TestBase
    {
        [TestMethod]
        public void Rotate_FromNorthOneTime_MoveOne_ExpectDead()
        {
            var board = MakeBoard();

            var expected = true;

            board.Run(
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 1 ) );

            Assert.AreEqual( expected, board.Turtle.Dead );
        }

        [TestMethod]
        public void MoveOne_RotateOne_MoveThree_RotateOne_MoveOne_ExpectDead()
        {
            var board = MakeBoard();

            var expected = true;

            board.Run(
                new Sequence( SequenceType.Move, 1 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 3 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 1 ) );

            Assert.AreEqual( expected, board.Turtle.Dead );
        }

        [TestMethod]
        public void MoveOne_RotateOne_MoveTwo_RotateOne_MoveOne_ExpectAlive()
        {
            var board = MakeBoard();

            var expected = false;

            board.Run(
                new Sequence( SequenceType.Move, 1 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 2 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 1 ) );

            Assert.AreEqual( expected, board.Turtle.Dead );
        }

        [TestMethod]
        public void MoveOne_RotateOne_MoveFour_RotateOne_MoveTwo_ExpectExited()
        {
            var board = MakeBoard();

            var expected = true;

            board.Run(
                new Sequence( SequenceType.Move, 1 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 4 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 2 ) );

            Assert.AreEqual( expected, board.Turtle.Exited );
        }
    }
}
