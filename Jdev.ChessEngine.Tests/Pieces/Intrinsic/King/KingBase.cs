namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using ChessEngine.Pieces;

public class KingBase : IntrinsicBase
{
    [SetUp]
    public void KingBaseSetUp()
    {
        Piece = new King();
    }
}