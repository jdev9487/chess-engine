namespace Jdev.ChessEngine.Tests.Square;

using Board;

[TestFixture]
public class EnclosingPositiveDiagonal
{
    
    private ISquare _square = default!;
    private ISquare[] _enclosingDiagonal = default!;
    
    [SetUp]
    public void SetUp()
    {
        _square = Square.At(File.D, Rank.Four);
        _enclosingDiagonal = _square.GetEnclosingPositiveDiagonal().ToArray();
    }

    [Test]
    [TestCaseSource(nameof(_cases))]
    public void SquareShouldBeInEnclosingFile(File file, Rank rank) =>
        Assert.That(_enclosingDiagonal, Contains.Item(Square.At(file, rank)));

    [Test]
    public void EnclosingFileShouldContain8Squares() => Assert.That(_enclosingDiagonal, Has.Length.EqualTo(8));

    private static object[] _cases =
    [
        new object[] { File.A, Rank.One },
        new object[] { File.B, Rank.Two },
        new object[] { File.C, Rank.Three },
        new object[] { File.D, Rank.Four },
        new object[] { File.E, Rank.Five },
        new object[] { File.F, Rank.Six },
        new object[] { File.G, Rank.Seven },
        new object[] { File.H, Rank.Eight }
    ];
}