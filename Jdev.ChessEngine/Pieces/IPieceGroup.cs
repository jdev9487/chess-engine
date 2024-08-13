namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public interface IPieceGroup
{
    IList<BasePiece> Pieces { get; }
    BasePiece? PieceAt(File file, Rank rank);
    public King King(Colour colour);
}