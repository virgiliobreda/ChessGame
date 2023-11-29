using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Chess
{
    internal class Queen : Piece
    {
        public Queen(BoardChess board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "Q";
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

            // No
            Position.SetValues(Position.Row - 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[Position.Row, Position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {

                    break;
                }
                position.SetValues(position.Row - 1, position.Column - 1);
            }

            // Ne
            Position.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[Position.Row, Position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {

                    break;
                }
                position.SetValues(position.Row - 1, position.Column + 1);
            }

            // Se
            Position.SetValues(Position.Row + 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[Position.Row, Position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {

                    break;
                }
                position.SetValues(position.Row + 1, position.Column + 1);
            }

            // So
            Position.SetValues(Position.Row + 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                mat[Position.Row, Position.Column] = true;

                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {

                    break;
                }
                position.SetValues(position.Row + 1, position.Column - 1);
            }

            return mat;

        }

    }
}
