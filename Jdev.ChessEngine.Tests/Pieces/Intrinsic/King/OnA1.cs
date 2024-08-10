namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnA1 : KingBase
{
    private Square[] _intrinsic = default!;
    
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.A, Rank.One);
        _intrinsic = Act();
    }
    
    [Test]
    [TestCase(File.A, Rank.Two)]
    [TestCase(File.B, Rank.Two)]
    [TestCase(File.B, Rank.One)]
    public void ShouldContainSquares(File file, Rank rank)
    {
        Assert.That(_intrinsic, Contains.Item(Square.At(file, rank)));
    }

    [Test]
    public void ShouldOnlyHave3Squares()
    {
        Assert.That(_intrinsic, Has.Length.EqualTo(3));
    }
}