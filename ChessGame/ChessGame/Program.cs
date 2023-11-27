using ChessGame.Board;
using ChessGame.Chess;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BoardChess board = new BoardChess(8, 8);

                board.PlacePiece(new Tower(board, Color.Black), new Position(0, 0));
                board.PlacePiece(new Tower(board, Color.Black), new Position(1, 3));
                board.PlacePiece(new King(board, Color.Black), new Position(2, 2));

                board.PlacePiece(new Tower(board, Color.White), new Position(3, 5));


                Display.PrintDisplay(board);
            }

            catch (BoardException ex) 
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}