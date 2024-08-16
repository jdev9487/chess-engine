namespace Jdev.ChessEngine.Tests.Square;

using Board;

[TestFixture]
public class EnclosingFile
{
    private ISquare _square = default!;
    private ISquare[] _enclosingFile = default!;
    
    [SetUp]
    public void SetUp()
    {
        _square = Square.At(File.D, Rank.Four);
        _enclosingFile = _square.GetEnclosingFile().ToArray();
    }

    [Test]
    [TestCaseSource(nameof(_cases))]
    public void SquareShouldBeInEnclosingFile(File file, Rank rank) =>
        Assert.That(_enclosingFile, Contains.Item(Square.At(file, rank)));

    [Test]
    public void EnclosingFileShouldContain8Squares() => Assert.That(_enclosingFile, Has.Length.EqualTo(8));

    private static object[] _cases =
    [
        new object[] { File.D, Rank.One },
        new object[] { File.D, Rank.Two },
        new object[] { File.D, Rank.Three },
        new object[] { File.D, Rank.Four },
        new object[] { File.D, Rank.Five },
        new object[] { File.D, Rank.Six },
        new object[] { File.D, Rank.Seven },
        new object[] { File.D, Rank.Eight }
    ];
}