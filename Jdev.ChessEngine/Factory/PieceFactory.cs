namespace Jdev.ChessEngine.Factory;

using Enums;
using Interfaces;
using Models;
using Pieces;

public class PieceFactory : IPieceFactory
{
    public IPiece Create(PieceType pieceType, Square location, Colour colour)
    {
        return pieceType switch
        {
            PieceType.King => new King { Position = location, Colour = colour },
            PieceType.Queen => new Queen { Position = location, Colour = colour },
            PieceType.Rook => new Rook { Position = location, Colour = colour },
            PieceType.Bishop => new Bishop { Position = location, Colour = colour },
            PieceType.Knight => new Knight { Position = location, Colour = colour },
            PieceType.Pawn => new Pawn { Position = location, Colour = colour },
            _ => throw new ArgumentOutOfRangeException(nameof(pieceType), pieceType, null)
        };
    }
}