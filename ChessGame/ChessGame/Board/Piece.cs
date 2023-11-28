using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountMovements { get; protected set; }
        public BoardChess Board { get; protected set; }

        public Piece(Color color, BoardChess board)
        {
            Position = null;
            Color = color;
            AmountMovements = 0;
            Board = board;
        }

        public void IncrementMovement()
        {
            AmountMovements++;
        }

        public abstract bool[,] PossibleMoviments();
    }
}
