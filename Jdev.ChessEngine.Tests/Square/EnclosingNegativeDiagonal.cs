namespace Jdev.ChessEngine.Tests.Square;

using Board;

[TestFixture]
public class EnclosingNegativeDiagonal
{
    
    private ISquare _square = default!;
    private ISquare[] _enclosingDiagonal = default!;
    
    [SetUp]
    public void SetUp()
    {
        _square = Square.At(File.D, Rank.Four);
        _enclosingDiagonal = _square.GetEnclosingNegativeDiagonal().ToArray();
    }

    [Test]
    [TestCaseSource(nameof(_cases))]
    public void SquareShouldBeInEnclosingFile(File file, Rank rank) =>
        Assert.That(_enclosingDiagonal, Contains.Item(Square.At(file, rank)));

    [Test]
    public void EnclosingFileShouldContain7Squares() => Assert.That(_enclosingDiagonal, Has.Length.EqualTo(7));

    private static object[] _cases =
    [
        new object[] { File.A, Rank.Seven },
        new object[] { File.B, Rank.Six },
        new object[] { File.C, Rank.Five },
        new object[] { File.D, Rank.Four },
        new object[] { File.E, Rank.Three },
        new object[] { File.F, Rank.Two },
        new object[] { File.G, Rank.One }
    ];
}