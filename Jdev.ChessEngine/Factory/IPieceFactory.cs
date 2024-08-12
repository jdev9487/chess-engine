namespace Jdev.ChessEngine.Factory;

using Board;
using Enums;
using Pieces;

public interface IPieceFactory
{
    T Create<T>(Square location, Colour colour) where T : BasePiece, new();
    King CreateKing(Square location, Colour colour, Rook queenside, Rook kingside);
    Rook CreateRook(Square location, Colour colour, Square castlingLocation);
}