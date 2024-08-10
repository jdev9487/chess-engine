namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Queen;

using ChessEngine.Pieces;

public class QueenBase : IntrinsicBase
{
    [SetUp] public void QueenBaseSetUp() => Piece = new Queen();
}