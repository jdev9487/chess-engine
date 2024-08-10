namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Models;
using Jdev.ChessEngine.Pieces;

public class IntrinsicBase
{
    private protected BasePiece Piece = default!;

    private protected Square[] Act() => Piece.GetIntrinsicRelocations()
        .Select(mp => mp.Target)
        .ToArray();
}