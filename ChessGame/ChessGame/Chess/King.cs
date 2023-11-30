using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Chess
{
    internal class King : Piece
    {

        private ChessMatch TheChessMatch;

        public King(BoardChess board, Color color, ChessMatch chessMacth) 
            : base(color, board)
        {
            TheChessMatch = chessMacth;

        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
        }



        private bool TestTowerForCastling(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Tower && p.Color == Color && p.AmountMovements == 0;
        }


        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            {
                
                Position pos = new Position(0, 0);

                // Up
                pos.SetValues(Position.Row -1, Position.Column);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Ne 
                pos.SetValues(Position.Row - 1, Position.Column + 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Right
                pos.SetValues(Position.Row, Position.Column + 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Se
                pos.SetValues(Position.Row + 1, Position.Column + 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Down
                pos.SetValues(Position.Row + 1, Position.Column);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // So 
                pos.SetValues(Position.Row + 1, Position.Column - 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // Left
                pos.SetValues(Position.Row, Position.Column - 1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // No  
                pos.SetValues(Position.Row - 1, Position.Column -1);

                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }


                // Castling
                if (AmountMovements == 0 && !TheChessMatch.Check)
                {
                    Position posT1 = new Position(Position.Row, Position.Column + 3); 

                    if (TestTowerForCastling(posT1))
                    {
                        Position p1 = new Position(Position.Row, Position.Column + 1);
                        Position p2 = new Position(Position.Row, Position.Column + 2);

                        if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                        {
                            mat[Position.Row, Position.Column + 2] = true;
                        }

                    }


                    Position posT2 = new Position(Position.Row, Position.Column - 4);

                    if (TestTowerForCastling(posT2))
                    {
                        Position p1 = new Position(Position.Row, Position.Column - 1);
                        Position p2 = new Position(Position.Row, Position.Column - 2);
                        Position p3 = new Position(Position.Row, Position.Column - 3);

                        if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                        {
                            mat[Position.Row, Position.Column - 2] = true;
                        }

                    }
                }
                

                return mat;

            }
        }
    }
}
