namespace Jdev.ChessEngine.Tests.Pieces.King.Intrinsic;

using Models;
using ChessEngine.Pieces;

public class Base
{
    private protected King King = default!;

    [SetUp]
    public void SetUp()
    {
        King = new King();
    }

    private protected Square[] Act() => King.GetIntrinsicRelocations()
        .Select(mp => mp.Target)
        .ToArray();
}