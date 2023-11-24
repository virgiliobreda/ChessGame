using ChessGame.Board;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BoardChess board = new BoardChess(8, 8); 

            Position p = new Position(3, 4);
            Console.WriteLine($"Position: {p}");


        }
    }
}