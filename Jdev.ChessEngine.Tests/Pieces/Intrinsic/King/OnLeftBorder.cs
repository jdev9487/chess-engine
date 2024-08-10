namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.King;

using Enums;
using Models;

[TestFixture]
public class OnLeftBorder : KingBase
{
    private Square[] _intrinsic = default!;
    
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.A, Rank.Four);
        _intrinsic = Act();
    }
    
    [Test]
    [TestCase(File.B, Rank.Three)]
    [TestCase(File.B, Rank.Four)]
    [TestCase(File.B, Rank.Five)]
    [TestCase(File.A, Rank.Three)]
    [TestCase(File.A, Rank.Five)]
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