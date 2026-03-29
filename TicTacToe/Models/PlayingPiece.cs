using TicTacToe.Enums;

namespace TicTacToe.Models
{
    public class PlayingPiece
    {
        public PieceType _pieceType;

        public PlayingPiece(PieceType pieceType)
        {
            _pieceType = pieceType;
        }
    }
}