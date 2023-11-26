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
    }
}
