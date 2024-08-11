namespace Jdev.ChessEngine.Models;

using Board;
using Pieces;

public class PieceGroup
{
    public IList<BasePiece> Pieces { get; init; } = default!;

    public BasePiece? PieceAt(File file, Rank rank) => Pieces.SingleOrDefault(p => p.Position == Square.At(file, rank));
}