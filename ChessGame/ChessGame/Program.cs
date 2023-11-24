using ChessGame.Board;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BoardChess board = new BoardChess(8, 8); 

            Display.PrintDisplay(board);


        }
    }
}