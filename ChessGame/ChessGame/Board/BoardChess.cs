﻿using System;
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
    }
}