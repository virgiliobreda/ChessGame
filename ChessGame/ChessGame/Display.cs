using ChessGame.Board;
using ChessGame.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Display
    {
        public static void PrintMatch(ChessMatch chessMatch)
        {
            PrintDisplay(chessMatch.Board);
            Console.WriteLine();
            PrintCapturedPieces(chessMatch);
            Console.WriteLine();
            Console.WriteLine("Turn: " + chessMatch.Turn);

            if (!chessMatch.FinishedMatch)
            {
                Console.WriteLine("Waiting for a move: " + chessMatch.CurrentPlayer);

                if (chessMatch.Check)
                {
                    Console.WriteLine("Check");
                }
            }

            else
            {
                Console.WriteLine("CHECK MATE!");
                Console.Write($"Winner: {chessMatch.CurrentPlayer}");
            }
        }


        public static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            PrintSet(chessMatch.CapturedColorPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(chessMatch.CapturedColorPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> setPieces)
        {
            Console.Write("[");
            foreach (Piece p in setPieces)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");

        }
        public static void PrintDisplay(BoardChess board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {

                    PrintPiece(board.Piece(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintDisplay(BoardChess board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor grayBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j] == true)
                    {
                        Console.BackgroundColor = grayBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static PositionChess ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new PositionChess(column, row);
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }

            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }

                else
                {
                    ConsoleColor sup = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = sup;
                }
                Console.Write(" ");
            }
        }
    }


}
