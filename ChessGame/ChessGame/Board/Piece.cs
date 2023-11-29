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

        public void DescrementMovement()
        {
            AmountMovements--;
        }

        public bool AreTherePossibleMoviments()
        {
            bool[,] mat = PossibleMoviments();
            for (int i = 0; i < Board.Rows;  i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }
                }          
            }
            return false;
            
        }

        public bool CanMove(Position position)
        {
            return PossibleMoviments()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMoviments();
    }
}
