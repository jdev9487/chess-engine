namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Queen;

using Enums;
using Models;

[TestFixture]
public class NotOnBorder : QueenBase
{
    [SetUp]
    public void NotOnBorderSetUp()
    {
        Piece.Position = Square.At(File.D, Rank.Four);
        Act();
    }

    [Test]
    [TestCase(File.A, Rank.Four)]
    [TestCase(File.B, Rank.Four)]
    [TestCase(File.C, Rank.Four)]
    [TestCase(File.E, Rank.Four)]
    [TestCase(File.F, Rank.Four)]
    [TestCase(File.G, Rank.Four)]
    [TestCase(File.H, Rank.Four)]
    [TestCase(File.D, Rank.One)]
    [TestCase(File.D, Rank.Two)]
    [TestCase(File.D, Rank.Three)]
    [TestCase(File.D, Rank.Five)]
    [TestCase(File.D, Rank.Six)]
    [TestCase(File.D, Rank.Seven)]
    [TestCase(File.D, Rank.Eight)]
    [TestCase(File.A, Rank.One)]
    [TestCase(File.B, Rank.Two)]
    [TestCase(File.C, Rank.Three)]
    [TestCase(File.E, Rank.Five)]
    [TestCase(File.F, Rank.Six)]
    [TestCase(File.G, Rank.Seven)]
    [TestCase(File.H, Rank.Eight)]
    [TestCase(File.A, Rank.Seven)]
    [TestCase(File.B, Rank.Six)]
    [TestCase(File.C, Rank.Five)]
    [TestCase(File.E, Rank.Three)]
    [TestCase(File.F, Rank.Two)]
    [TestCase(File.G, Rank.One)]
    public void ShouldContainSquares(File file, Rank rank) => AssertContains(file, rank);

    [Test]
    public void ShouldContain27Squares() => AssertHasLength(27);
}