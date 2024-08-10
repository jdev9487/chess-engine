namespace Jdev.ChessEngine.Tests.Pieces.King.Intrinsic;

using Enums;
using Models;

[TestFixture]
public class OnH8 : Base
{
    private Square[] _intrinsic = default!;
    
    [SetUp]
    public void NotOnBorderSetUp()
    {
        King.Position = Square.At(File.H, Rank.Eight);
        _intrinsic = Act();
    }
    
    [Test]
    [TestCase(File.H, Rank.Seven)]
    [TestCase(File.G, Rank.Seven)]
    [TestCase(File.G, Rank.Eight)]
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