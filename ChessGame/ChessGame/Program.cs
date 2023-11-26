using ChessGame.Board;
using ChessGame.Chess;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BoardChess board = new BoardChess(8, 8);

            board.PlacePart(new Tower(board, Color.Blue), new Position(0, 0));
            board.PlacePart(new Tower(board, Color.Blue), new Position(1, 3));
            board.PlacePart(new King(board, Color.Blue), new Position(2, 4));

            Display.PrintDisplay(board);


        }
    }
}