using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Chess
{
    internal class ChessMatch
    {
        public BoardChess Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; set; }
        public bool FinishedMatch { get; private set; } 

        public ChessMatch()
        {
            Board = new BoardChess(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
            FinishedMatch = false;
            PlacePiece();
        }

        public void ExecuteMovement(Position originPosition, Position targetPosition)
        {
            Piece p = Board.RemovePiece(originPosition);
            p.IncrementMovement();
            Piece capturedPiece = Board.RemovePiece(targetPosition);
            Board.PlacePiece(p, targetPosition);

        }

        private void PlacePiece()
        {
            Board.PlacePiece(new Tower(Board, Color.White), new PositionChess('c', 1).ToPosition());
            Board.PlacePiece(new Tower(Board, Color.White), new PositionChess('c', 2).ToPosition());
            Board.PlacePiece(new Tower(Board, Color.White), new PositionChess('d', 2).ToPosition());
            Board.PlacePiece(new Tower(Board, Color.White), new PositionChess('e', 2).ToPosition());
            Board.PlacePiece(new Tower(Board, Color.White), new PositionChess('e', 1).ToPosition());
            Board.PlacePiece(new King(Board, Color.White), new PositionChess('d', 1).ToPosition());

            Board.PlacePiece(new Tower(Board, Color.Black), new PositionChess('c', 7).ToPosition());
            Board.PlacePiece(new Tower(Board, Color.Black), new PositionChess('c', 8).ToPosition());
            Board.PlacePiece(new Tower(Board, Color.Black), new PositionChess('d', 7).ToPosition());
            Board.PlacePiece(new Tower(Board, Color.Black), new PositionChess('e', 7).ToPosition());
            Board.PlacePiece(new Tower(Board, Color.Black), new PositionChess('e', 8).ToPosition());
            Board.PlacePiece(new King(Board, Color.Black), new PositionChess('d', 8).ToPosition());

        }
    }
}
