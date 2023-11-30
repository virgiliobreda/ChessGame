using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        private HashSet<Piece> Parts;
        private HashSet<Piece> CapturedParts;
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new BoardChess(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            FinishedMatch = false;
            Check = false;
            Parts = new HashSet<Piece>();
            CapturedParts = new HashSet<Piece>();
            PlacePiece();
        }

        public Piece ExecuteMovement(Position originPosition, Position targetPosition)
        {
            Piece p = Board.RemovePiece(originPosition);
            p.IncrementMovement();
            Piece capturedPiece = Board.RemovePiece(targetPosition);
            Board.PlacePiece(p, targetPosition);

            if (capturedPiece != null)
            {
                CapturedParts.Add(capturedPiece);
            }


            // Castling
            if (p is King && targetPosition.Column == originPosition.Column + 2)
            {
                Position originTower = new Position(originPosition.Row, originPosition.Column + 3);
                Position targetTower = new Position(originPosition.Row, originPosition.Column + 1);

                Piece T = Board.RemovePiece(originTower);
                T.IncrementMovement();
                Board.PlacePiece(T, targetTower);
            }

            if (p is King && targetPosition.Column == originPosition.Column - 2)
            {
                Position originTower = new Position(originPosition.Row, originPosition.Column - 4);
                Position targetTower = new Position(originPosition.Row, originPosition.Column - 1);

                Piece T = Board.RemovePiece(originTower);
                T.IncrementMovement();
                Board.PlacePiece(T, targetTower);
            }





            return capturedPiece;
        }

        public void UndoMovement(Position originPosition, Position targetPosition, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(targetPosition);
            p.DescrementMovement();

            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, targetPosition);
                CapturedParts.Remove(capturedPiece);
            }
            Board.PlacePiece(p, originPosition);


            // Castling

            if (p is King && targetPosition.Column == originPosition.Column + 2)
            {
                Position originTower = new Position(originPosition.Row, originPosition.Column + 3);
                Position targetTower = new Position(originPosition.Row, originPosition.Column + 1);

                Piece T = Board.RemovePiece(targetTower);
                T.DescrementMovement();
                Board.PlacePiece(T, originTower);
            }


            if (p is King && targetPosition.Column == originPosition.Column - 2)
            {
                Position originTower = new Position(originPosition.Row, originPosition.Column - 4);
                Position targetTower = new Position(originPosition.Row, originPosition.Column - 1);

                Piece T = Board.RemovePiece(targetTower);
                T.DescrementMovement();
                Board.PlacePiece(T, originTower);
            }
        }

        public void MakesPlay(Position originPosition, Position targetPosition)
        {
            Piece capturedPiece = ExecuteMovement(originPosition, targetPosition);

            if (IsInCheckMate(CurrentPlayer))
            {
                UndoMovement(originPosition, targetPosition, capturedPiece);
                throw new BoardException("You can't put yourself in checkmate ");
            }

            Piece p = Board.Piece(targetPosition);

            if (IsInCheckMate(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (TestCheckMate(Opponent(CurrentPlayer)))
            {
                FinishedMatch = true;
            }
            else
            {
                Turn++;
                PlayerSwap();
            }
            
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("There is no part in the chosen origin position");
            }

            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("The original piece you choose is not yours");
            }

            if (!Board.Piece(position).AreTherePossibleMoviments())
            {
                throw new BoardException("There are no possible movements for the original piece");
            }

        }

        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (!Board.Piece(origin).CanMove(target))
            {
                throw new BoardException("Target position invalid");
            }
        }


        private void PlayerSwap()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }



        public HashSet<Piece> CapturedColorPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in CapturedParts)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }


        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Parts)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedColorPieces(color));
            return aux;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }

            else
            {
                return Color.White;
            }
        }

        private Piece KingCheck(Color color)
        {
            foreach (Piece piece in PiecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheckMate(Color cor)
        {
            Piece kingPiece = KingCheck(cor);
            if (kingPiece == null)
            {
                throw new BoardException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Piece x in PiecesInGame(Opponent(cor)))
            {
                bool[,] mat = x.PossibleMoviments();
                if (mat[kingPiece.Position.Row, kingPiece.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestCheckMate(Color color)
        {
            if (!IsInCheckMate(color))
            {
                return false;
            }

            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] mat = x.PossibleMoviments();
                for (int i = 0;  i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j] == true)
                        {
                            Position origin = x.Position;
                            Position targetPosition = new Position(i, j);
                            Piece capturedPiece = ExecuteMovement(origin, targetPosition);
                            bool testCheck = IsInCheckMate(color);
                            UndoMovement(origin, targetPosition, capturedPiece);

                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new PositionChess(column, row).ToPosition());
            Parts.Add(piece);
        }

        private void PlacePiece()
        {
            PlaceNewPiece('a', 1, new Tower(Board, Color.White));
            PlaceNewPiece('b', 1, new Horse(Board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('d', 1, new Queen(Board, Color.White));
            PlaceNewPiece('e', 1, new King(Board, Color.White, this));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 1, new Horse(Board, Color.White));
            PlaceNewPiece('h', 1, new Tower(Board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White, this));


            PlaceNewPiece('a', 8, new Tower(Board, Color.Black));
            PlaceNewPiece('b', 8, new Horse(Board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black, this));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('g', 8, new Horse(Board, Color.Black));
            PlaceNewPiece('h', 8, new Tower(Board, Color.Black));
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Black, this));

        }
    }
}
