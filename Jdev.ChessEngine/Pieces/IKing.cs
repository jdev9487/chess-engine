namespace Jdev.ChessEngine.Pieces;

using Board;

public interface IKing : IPiece
{
    IRook? GetCastlingRook(ISquare destination);
    bool HasMoved { get; set; }
}