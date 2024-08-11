namespace Jdev.ChessEngine.Factory;

using Board;
using Enums;
using Models;
using Pieces;

public class PieceFactory : IPieceFactory
{
    public T Create<T>(Square location, Colour colour) where T : BasePiece, new()
        => new() { Position = location, Colour = colour };

    public Rook CreateRook(Square location, Colour colour, Square castlingLocation) => new()
        { Position = location, Colour = colour, CastlingLocation = castlingLocation };

    public King CreateKing(Square location, Colour colour, Rook queenside, Rook kingside) => new()
        { Position = location, Colour = colour, QueensideRook = queenside, KingsideRook = kingside };
}