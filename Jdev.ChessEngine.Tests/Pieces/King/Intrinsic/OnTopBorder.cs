namespace Jdev.ChessEngine.Tests.Pieces.King.Intrinsic;

using Enums;
using Models;

[TestFixture]
public class OnTopBorder : Base
{
    private Square[] _intrinsic = default!;
    
    [SetUp]
    public void NotOnBorderSetUp()
    {
        King.Position = Square.At(File.E, Rank.Eight);
        _intrinsic = Act();
    }
    
    [Test]
    [TestCase(File.D, Rank.Eight)]
    [TestCase(File.D, Rank.Seven)]
    [TestCase(File.E, Rank.Seven)]
    [TestCase(File.F, Rank.Seven)]
    [TestCase(File.F, Rank.Eight)]
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