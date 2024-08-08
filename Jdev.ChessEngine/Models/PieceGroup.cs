namespace Jdev.ChessEngine.Models;

using Enums;
using Interfaces;

public class PieceGroup
{
    public IList<IPiece> Pieces { get; init; } = default!;

    public IPiece? PieceAt(File file, Rank rank) => Pieces.SingleOrDefault(p => p.Position == Square.At(file, rank));
}