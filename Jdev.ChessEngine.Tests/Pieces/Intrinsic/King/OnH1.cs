namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnH1 : KingBase
{
    private Square[] _intrinsic = default!;
    
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.H, Rank.One);
        _intrinsic = Act();
    }
    
    [Test]
    [TestCase(File.H, Rank.Two)]
    [TestCase(File.G, Rank.Two)]
    [TestCase(File.G, Rank.One)]
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