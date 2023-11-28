using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Chess
{
    internal class Tower : Piece
    {
        public Tower(BoardChess board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            // up 
            position.SetValues(Position.Row - 1, Position.Column);

            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row = position.Row - 1;
            }

            // Down
            position.SetValues(Position.Row + 1, Position.Column);

            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row = position.Row + 1;

            }

            // Right
            position.SetValues(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Column = position.Column + 1;

            }

            // Left 
            position.SetValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Column = position.Column - 1;

            }

            return mat;
        }
    }
}
