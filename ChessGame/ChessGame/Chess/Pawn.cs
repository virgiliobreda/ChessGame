using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Chess
{
    internal class Pawn : Piece
    {
        public Pawn(BoardChess board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        private bool ThereEnemy(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null || p.Color != Color;
        }

        private bool Free(Position position)
        {
            Piece p = Board.Piece(position);
            return Board.Piece(position) != null;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.SetValues(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 2, Position.Column);
                if (Board.ValidPosition(position) && Free(position) && AmountMovements == 0)
                {
                    mat[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ThereEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ThereEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }
            }
            else
            {
                position.SetValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row + 2, Position.Column);
                if (Board.ValidPosition(position) && Free(position) && AmountMovements == 0)
                {
                    mat[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ThereEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }

                position.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ThereEnemy(position))
                {
                    mat[position.Row, position.Column] = true;
                }
            }
            return mat;
        }
    }
}
