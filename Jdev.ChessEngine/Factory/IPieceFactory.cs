namespace Jdev.ChessEngine.Factory;

using Board;
using Enums;
using Pieces;

public interface IPieceFactory
{
    T Create<T>(ISquare location, Colour colour) where T : IPiece, new();
    King CreateKing(ISquare location, Colour colour, Rook queenside, Rook kingside);
    Rook CreateRook(ISquare location, Colour colour, ISquare castlingLocation);
}