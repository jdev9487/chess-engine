namespace Jdev.ChessEngine.Tests.Pieces.King.Intrinsic;

using Enums;
using Models;

[TestFixture]
public class OnBottomBorder : Base
{
    private Square[] _intrinsic = default!;
    
    [SetUp]
    public void NotOnBorderSetUp()
    {
        King.Position = Square.At(File.E, Rank.One);
        _intrinsic = Act();
    }
    
    [Test]
    [TestCase(File.D, Rank.One)]
    [TestCase(File.D, Rank.Two)]
    [TestCase(File.E, Rank.Two)]
    [TestCase(File.F, Rank.Two)]
    [TestCase(File.F, Rank.One)]
    public void ShouldContainSquares(File file, Rank rank)
    {
        Assert.That(_intrinsic, Contains.Item(Square.At(file, rank)));
    }

    [Test]
    public void ShouldOnlyHave5Squares()
    {
        Assert.That(_intrinsic, Has.Length.EqualTo(5));
    }
}