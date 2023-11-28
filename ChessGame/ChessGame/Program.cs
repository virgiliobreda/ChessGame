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
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.FinishedMatch)
                {
                    Console.Clear();
                    Display.PrintDisplay(chessMatch.Board);

                    Console.WriteLine();

                    Console.Write("Origin: ");
                    Position origin = Display.ReadPosition().ToPosition();

                    bool[,] possiblePositions = chessMatch.Board.Piece(origin).PossibleMoviments(); 

                    Console.Clear();
                    Display.PrintDisplay(chessMatch.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Target: ");
                    Position target = Display.ReadPosition().ToPosition(); 

                    chessMatch.ExecuteMovement(origin, target);
                }
                


                Display.PrintDisplay(chessMatch.Board);
            }

            catch (BoardException ex) 
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}