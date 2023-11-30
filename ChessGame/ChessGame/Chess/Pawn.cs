using ChessGame.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Chess
{
    internal class Pawn : Piece
    {
        private ChessMatch TheChessMatch;

        public Pawn(BoardChess tab, Color cor, ChessMatch chessMatch) : base(cor, tab)
        {
            TheChessMatch = chessMatch;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ThereEnemy(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.Piece(pos) == null;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.SetValues(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row - 2, Position.Column);
                Position p2 = new Position(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(p2) && Free(p2) && Board.ValidPosition(pos) && Free(pos) && AmountMovements == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ThereEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ThereEnemy(pos))
                {
                    mat[pos.Row, pos.Row] = true;
                }

                // En passant
                
                if (Position.Row == 3)
                {
                    Position leftPosition = new Position(Position.Row, Position.Column -1 );
                    
                    if (Board.ValidPosition(leftPosition) && ThereEnemy(leftPosition) && Board.Piece(leftPosition) == TheChessMatch.VunerablePieceEnPassant){
                        mat[leftPosition.Row - 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(Position.Row, Position.Column + 1);

                    if (Board.ValidPosition(rightPosition) && ThereEnemy(rightPosition) && Board.Piece(rightPosition) == TheChessMatch.VunerablePieceEnPassant)
                    {
                        mat[rightPosition.Row - 1, rightPosition.Column] = true;
                    }
                }

                
            }
            else
            {
                pos.SetValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row + 2, Position.Column);
                Position p2 = new Position(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(p2) && Free(p2) && Board.ValidPosition(pos) && Free(pos) && AmountMovements == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ThereEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ThereEnemy(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // En passant

                if (Position.Row == 4)
                {
                    Position leftPosition = new Position(Position.Row, Position.Column - 1);

                    if (Board.ValidPosition(leftPosition) && ThereEnemy(leftPosition) && Board.Piece(leftPosition) == TheChessMatch.VunerablePieceEnPassant)
                    {
                        mat[leftPosition.Row + 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(Position.Row, Position.Column + 1);

                    if (Board.ValidPosition(rightPosition) && ThereEnemy(rightPosition) && Board.Piece(rightPosition) == TheChessMatch.VunerablePieceEnPassant)
                    {
                        mat[rightPosition.Row + 1, rightPosition.Column] = true;
                    }
                }

            }

            return mat;
        }
    }
}
    