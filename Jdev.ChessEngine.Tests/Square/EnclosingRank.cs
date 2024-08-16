namespace Jdev.ChessEngine.Tests.Square;

using Board;

[TestFixture]
public class EnclosingRank
{
    private ISquare _square = default!;
    private ISquare[] _enclosingRank = default!;
    
    [SetUp]
    public void SetUp()
    {
        _square = Square.At(File.D, Rank.Four);
        _enclosingRank = _square.GetEnclosingRank().ToArray();
    }

    [Test]
    [TestCaseSource(nameof(_cases))]
    public void SquareShouldBeInEnclosingRank(File file, Rank rank) =>
        Assert.That(_enclosingRank, Contains.Item(Square.At(file, rank)));

    [Test]
    public void EnclosingRankShouldContain8Squares() => Assert.That(_enclosingRank, Has.Length.EqualTo(8));

    private static object[] _cases =
    [
        new object[] { File.A, Rank.Four },
        new object[] { File.B, Rank.Four },
        new object[] { File.C, Rank.Four },
        new object[] { File.D, Rank.Four },
        new object[] { File.E, Rank.Four },
        new object[] { File.F, Rank.Four },
        new object[] { File.G, Rank.Four },
        new object[] { File.H, Rank.Four }
    ];
}