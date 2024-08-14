namespace Jdev.ChessEngine.Tests.Square;

using Board;

[TestFixture]
public class DiagonalsInBetween
{
    [Test]
    [TestCaseSource(nameof(_positiveDiagonals))]
    public void SquareShouldBeInPositiveDiagonals(File file, Rank rank)
    {
        var (a, b) = GetPositive();
        var inBetween = a.GetDiagonalsInBetween(b);
        Assert.That(inBetween, Contains.Item(Square.At(file, rank)));
    }
    
    [Test]
    [TestCaseSource(nameof(_negativeDiagonals))]
    public void SquareShouldBeInNegativeDiagonals(File file, Rank rank)
    {
        var (a, b) = GetNegative();
        var inBetween = a.GetDiagonalsInBetween(b);
        Assert.That(inBetween, Contains.Item(Square.At(file, rank)));
    }

    [Test]
    public void PositiveShouldHaveCorrectLength()
    {
        var (a, b) = GetPositive();
        var inBetween = a.GetDiagonalsInBetween(b).ToArray();
        Assert.That(inBetween, Has.Length.EqualTo(_positiveDiagonals.Length));
    }

    [Test]
    public void NegativeShouldHaveCorrectLength()
    {
        var (a, b) = GetNegative();
        var inBetween = a.GetDiagonalsInBetween(b).ToArray();
        Assert.That(inBetween, Has.Length.EqualTo(_negativeDiagonals.Length));
    }

    [Test]
    public void OffDiagonalShouldHaveZeroLength()
    {
        var (a, b) = GetOffDiagonal();
        var inBetween = a.GetDiagonalsInBetween(b).ToArray();
        Assert.That(inBetween, Is.Empty);
    }
    
    private static object[] _positiveDiagonals =
    [
        new object[] { File.C, Rank.Two },
        new object[] { File.D, Rank.Three },
        new object[] { File.E, Rank.Four },
        new object[] { File.F, Rank.Five }
    ];
    
    private static object[] _negativeDiagonals =
    [
        new object[] { File.B, Rank.Eight },
        new object[] { File.C, Rank.Seven },
        new object[] { File.D, Rank.Six }
    ];

    private static (ISquare, ISquare) GetPositive() => (Square.At(File.C, Rank.Two), Square.At(File.F, Rank.Five));
    private static (ISquare, ISquare) GetNegative() => (Square.At(File.B, Rank.Eight), Square.At(File.D, Rank.Six));

    private static (ISquare, ISquare) GetOffDiagonal() =>
        (Square.At(File.E, Rank.Eight), Square.At(File.G, Rank.Eight));
}