using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Chess
{
    internal class Horse : Piece
    {
        public Horse(BoardChess board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "H";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            {

                Position pos = new Position(0, 0);


                pos.SetValues(Position.Row - 1, Position.Column - 2);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }


                pos.SetValues(Position.Row - 2, Position.Column - 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row - 2, Position.Column + 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row - 1, Position.Column + 2);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row + 1, Position.Column + 2);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row + 2, Position.Column + 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row + 2, Position.Column - 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                pos.SetValues(Position.Row + 1, Position.Column - 2);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }


                return mat;
            }
        }
    }
}
