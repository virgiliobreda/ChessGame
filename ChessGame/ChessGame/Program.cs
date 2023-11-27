using ChessGame.Board;
using ChessGame.Chess;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PositionChess position = new PositionChess('c', 7);

            Console.WriteLine(position);

            Console.WriteLine(position.ToPosition());

        }
    }
}