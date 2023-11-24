﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountMovements { get; protected set; }
        public BoardChess Board { get; protected set; }

        public Piece(Position position, Color color, BoardChess board)
        {
            Position = position;
            Color = color;
            AmountMovements = 0;
            Board = board;
        }
    }
}