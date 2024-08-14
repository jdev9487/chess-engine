namespace Jdev.ChessEngine.Factory;

using Board;
using Enums;
using Pieces;

public class PieceFactory : IPieceFactory
{
    public T Create<T>(ISquare location, Colour colour) where T : IPiece, new()
        => new() { Position = location, Colour = colour };

    public Rook CreateRook(ISquare location, Colour colour, ISquare castlingLocation) => new()
        { Position = location, Colour = colour, CastlingLocation = castlingLocation };

    public King CreateKing(ISquare location, Colour colour, Rook queenside, Rook kingside) => new()
        { Position = location, Colour = colour, QueensideRook = queenside, KingsideRook = kingside };
}