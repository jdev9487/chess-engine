namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public interface IPieceGroup
{
    IList<IPiece> Pieces { get; }
    IPiece? PieceAt(File file, Rank rank);
    IPiece? PieceAt(Square location);
    public King King(Colour colour);
}