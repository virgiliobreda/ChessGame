using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Chess
{
    internal class King : Piece
    {
        public King(BoardChess board, Color color) 
            : base(color, board)
        {

        }

        public override string ToString()
        {
            return "R";
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

                // Up
                pos.SetValues(Position.Row -1, Position.Column);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Ne 
                pos.SetValues(Position.Row - 1, Position.Column + 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Right
                pos.SetValues(Position.Row, Position.Column + 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Se
                pos.SetValues(Position.Row + 1, Position.Column + 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Down
                pos.SetValues(Position.Row + 1, Position.Column);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // So 
                pos.SetValues(Position.Row + 1, Position.Column - 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Left
                pos.SetValues(Position.Row, Position.Column - 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // No  
                pos.SetValues(Position.Row - 1, Position.Column -1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                return mat;

            }
        }
    }
}
