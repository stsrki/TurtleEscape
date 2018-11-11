using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurtleEscape.Tests
{
    [TestClass]
    public class CollisionTests : TestBase
    {
        [TestMethod]
        public void OneMine_ExpectTrue()
        {
            var board = MakeBoard();
            board.Turtle.Position = new Position( 1, 1 );

            var expected = typeof( Mine );

            var collision = new Collision( board );

            var gameObject = collision.Check( board.Turtle );

            Assert.AreEqual( expected, gameObject.GetType() );
        }

        [TestMethod]
        public void MultipleMines_ExpectTrue()
        {
            var board = MakeBoard();
            board.Turtle.Position = new Position( 3, 1 );

            var expected = typeof( Mine );

            var collision = new Collision( board );

            var gameObject = collision.Check( board.Turtle );

            Assert.AreEqual( expected, gameObject.GetType() );
        }

        [TestMethod]
        public void MultipleMines_ExpectNull()
        {
            var board = MakeBoard();
            board.Turtle.Position = new Position( 2, 1 );

            var expected = typeof( Mine );

            var collision = new Collision( board );

            var gameObject = collision.Check( board.Turtle );

            Assert.IsNull( gameObject );
        }
    }
}
