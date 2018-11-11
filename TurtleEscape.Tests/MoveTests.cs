using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurtleEscape.Tests
{
    [TestClass]
    public class MoveTests : TestBase
    {
        [TestMethod]
        public void Move_NorthOne_Expect_x0_y0()
        {
            var board = MakeBoard();

            var expected = new Position( 0, 0 );

            board.Run(
                new Sequence( SequenceType.Move, 1 ) );

            Assert.AreEqual( expected, board.Turtle.Position );
        }

        [TestMethod]
        public void Move_NorthOne_RotateOne_MoveTwo_Expect_x2_y0()
        {
            var board = MakeBoard();

            var expected = new Position( 2, 0 );

            board.Run(
                new Sequence( SequenceType.Move, 1 ),
                new Sequence( SequenceType.Rotate, 1 ),
                new Sequence( SequenceType.Move, 2 ) );

            Assert.AreEqual( expected, board.Turtle.Position );
        }

        [TestMethod]
        public void MoveToWall_NorthTwo_Expect_x0_y0()
        {
            var board = MakeBoard();

            var expected = new Position( 0, 0 );

            board.Run(
                new Sequence( SequenceType.Move, 2 ) );

            Assert.AreEqual( expected, board.Turtle.Position );
        }

        [TestMethod]
        public void MoveToWall_WestOne_Expect_x0_y1()
        {
            var board = MakeBoard();
            board.Turtle.Rotation = Rotation.West;

            var expected = new Position( 0, 1 );

            board.Run(
                new Sequence( SequenceType.Move, 1 ) );

            Assert.AreEqual( expected, board.Turtle.Position );
        }
    }
}
