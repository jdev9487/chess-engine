namespace Jdev.ChessEngine.Tests.Pieces.King.Intrinsic;

using Enums;
using Models;

[TestFixture]
public class OnRightBorder : Base
{
    private Square[] _intrinsic = default!;
    
    [SetUp]
    public void NotOnBorderSetUp()
    {
        King.Position = Square.At(File.H, Rank.Four);
        _intrinsic = Act();
    }
    
    [Test]
    [TestCase(File.G, Rank.Three)]
    [TestCase(File.G, Rank.Four)]
    [TestCase(File.G, Rank.Five)]
    [TestCase(File.H, Rank.Three)]
    [TestCase(File.H, Rank.Five)]
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