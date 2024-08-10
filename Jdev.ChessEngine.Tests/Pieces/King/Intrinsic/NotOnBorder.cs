namespace Jdev.ChessEngine.Tests.Pieces.King.Intrinsic;

using Enums;
using Models;

[TestFixture]
public class NotOnBorder : Base
{
    private Square[] _intrinsic = default!;
    
    [SetUp]
    public void NotOnBorderSetUp()
    {
        King.Position = Square.At(File.D, Rank.Four);
        _intrinsic = Act();
    }
    
    [Test]
    [TestCase(File.C, Rank.Three)]
    [TestCase(File.C, Rank.Four)]
    [TestCase(File.C, Rank.Five)]
    [TestCase(File.D, Rank.Three)]
    [TestCase(File.D, Rank.Five)]
    [TestCase(File.E, Rank.Three)]
    [TestCase(File.E, Rank.Four)]
    [TestCase(File.E, Rank.Five)]
    public void ShouldContainSquares(File file, Rank rank)
    {
        Assert.That(_intrinsic, Contains.Item(Square.At(file, rank)));
    }

    [Test]
    public void ShouldOnlyHave8Squares()
    {
        Assert.That(_intrinsic, Has.Length.EqualTo(8));
    }
}