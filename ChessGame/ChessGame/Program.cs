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
                    try
                    {
                        Console.Clear();
                        
                        Display.PrintMatch(chessMatch);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Display.ReadPosition().ToPosition();
                        chessMatch.ValidateOriginPosition(origin);


                        bool[,] possiblePositions = chessMatch.Board.Piece(origin).PossibleMoviments();

                        Console.Clear();
                        Display.PrintDisplay(chessMatch.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Target: ");
                        Position target = Display.ReadPosition().ToPosition();
                        chessMatch.ValidateTargetPosition(origin, target);
                        

                        chessMatch.MakesPlay(origin, target);
                    }
                    catch (BoardException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Display.PrintMatch(chessMatch);
            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}