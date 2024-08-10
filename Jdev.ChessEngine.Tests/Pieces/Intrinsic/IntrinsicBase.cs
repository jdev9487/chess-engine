namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Enums;
using Models;
using Jdev.ChessEngine.Pieces;

public class IntrinsicBase
{
    private protected BasePiece Piece = default!;
    private protected Square[] Intrinsic = default!;

    private protected void Act() => Intrinsic = Piece.GetIntrinsicRelocations()
        .Select(mp => mp.Target)
        .ToArray();

    private protected void AssertContains(File file, Rank rank) =>
        Assert.That(Intrinsic, Contains.Item(Square.At(file, rank)));
    
    private protected void AssertHasLength(int length) =>
        Assert.That(Intrinsic, Has.Length.EqualTo(length));
}