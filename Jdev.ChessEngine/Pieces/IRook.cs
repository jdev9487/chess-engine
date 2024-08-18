namespace Jdev.ChessEngine.Pieces;

using Board;

public interface IRook : IPiece
{
    bool HasMoved { get; set; }
    ISquare CastlingLocation { get; init; }
}