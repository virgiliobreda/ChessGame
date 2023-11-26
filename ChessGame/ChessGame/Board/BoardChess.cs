using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    internal class BoardChess
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces { get; set; }


        public BoardChess(int row, int column)
        {
            Rows = row;
            Columns = column;
            Pieces = new Piece[Rows, Columns];
        }

       

        public Piece Piece(int row, int column)
        {
            return Pieces[row, column];
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public bool BusySquare(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void PlacePiece(Piece p, Position pos)
        {
            if (BusySquare(pos))
            {
                throw new BoardException("There is already a piece in this position");
            }
            Pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position) 
        {
            if (!ValidPosition(position)) 
            {
                throw new BoardException("Invalid position");
            }
        }
    }
}
