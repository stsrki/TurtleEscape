#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TurtleEscape
{
    public class Board
    {
        #region Members

        private readonly ILogger logger;

        private readonly Collision collision;

        #endregion

        #region Constructors

        public Board( ILogger logger )
        {
            this.logger = logger;

            collision = new Collision( this );
        }

        #endregion

        #region Methods

        public void Init( IGameSettings gameSettings )
        {
            Width = gameSettings.Width;
            Height = gameSettings.Height;

            Turtle = gameSettings.Turtle;

            GameObjects.Add( gameSettings.Turtle );

            foreach ( var mine in gameSettings.Mines )
                GameObjects.Add( mine );

            GameObjects.Add( gameSettings.Exit );

            for ( int i = 0; i < Width; ++i )
            {
                GameObjects.Add( new Wall { Position = new Position( i, -1 ) } );
                GameObjects.Add( new Wall { Position = new Position( i, Height + 1 ) } );
            }

            for ( int i = 0; i < Height; ++i )
            {
                GameObjects.Add( new Wall { Position = new Position( -1, i ) } );
                GameObjects.Add( new Wall { Position = new Position( Width + 1, i ) } );
            }
        }

        public void Run( params Sequence[] sequences )
        {
            foreach ( var sequence in sequences )
            {
                // rotation does not need to check for collision so it can go multiple rotation at once
                if ( sequence.Type == SequenceType.Rotate )
                    HandleRotations( sequence );
                else
                    HandleMoves( sequence );
            }

            if ( Turtle.Dead )
                logger.Danger( "Little turtle has died :(" );
            else if ( Turtle.Exited )
                logger.Success( "Little turtle has escaped! :)" );
            else
                logger.Danger( "Still in danger!" );
        }

        private void HandleRotations( Sequence sequence )
        {
            for ( int r = 0; r < sequence.Times; ++r )
            {
                Turtle.Rotate();

                logger.Info( $"Rotated {Turtle.Rotation}!" );
            }
        }

        private void HandleMoves( Sequence sequence )
        {
            for ( int m = 0; m < sequence.Times; ++m )
            {
                // although it can go multiple fields we need it just to move one field
                Turtle.Move();

                var collidedWith = collision.Check( Turtle );

                if ( collidedWith == null )
                {
                    logger.Info( $"Success!" );

                    continue;
                }

                collidedWith.Handle( logger, Turtle );

                if ( Turtle.Dead || Turtle.Exited )
                    break;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the board width.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the board height.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets the reference to the turtle game object.
        /// </summary>
        public Turtle Turtle { get; private set; }

        /// <summary>
        /// Gets the list of all the game objects.
        /// </summary>
        public List<GameObject> GameObjects { get; private set; } = new List<GameObject>();

        #endregion
    }
}
