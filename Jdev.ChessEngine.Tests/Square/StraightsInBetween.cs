namespace Jdev.ChessEngine.Tests.Square;

using Board;

[TestFixture]
public class StraightsInBetween
{
    [Test]
    [TestCaseSource(nameof(_horizontals))]
    public void SquareShouldBeInHorizontals(File file, Rank rank)
    {
        var (a, b) = GetHorizontal();
        var inBetween = a.GetStraightsInBetween(b);
        Assert.That(inBetween, Contains.Item(Square.At(file, rank)));
    }
    
    [Test]
    [TestCaseSource(nameof(_verticals))]
    public void SquareShouldBeInVerticals(File file, Rank rank)
    {
        var (a, b) = GetVertical();
        var inBetween = a.GetStraightsInBetween(b);
        Assert.That(inBetween, Contains.Item(Square.At(file, rank)));
    }

    [Test]
    public void HorizontalsShouldHaveCorrectLength()
    {
        var (a, b) = GetHorizontal();
        var inBetween = a.GetStraightsInBetween(b).ToArray();
        Assert.That(inBetween, Has.Length.EqualTo(_horizontals.Length));
    }

    [Test]
    public void VerticalsShouldHaveCorrectLength()
    {
        var (a, b) = GetVertical();
        var inBetween = a.GetStraightsInBetween(b).ToArray();
        Assert.That(inBetween, Has.Length.EqualTo(_verticals.Length));
    }

    [Test]
    public void OffStraightShouldHaveZeroLength()
    {
        var (a, b) = GetOffStraight();
        var inBetween = a.GetStraightsInBetween(b).ToArray();
        Assert.That(inBetween, Is.Empty);
    }
    
    private static object[] _horizontals =
    [
        new object[] { File.C, Rank.Two },
        new object[] { File.D, Rank.Two },
        new object[] { File.E, Rank.Two },
        new object[] { File.F, Rank.Two }
    ];
    
    private static object[] _verticals =
    [
        new object[] { File.B, Rank.Eight },
        new object[] { File.B, Rank.Seven },
        new object[] { File.B, Rank.Six },
        new object[] { File.B, Rank.Five }
    ];

    private static (ISquare, ISquare) GetHorizontal() => (Square.At(File.C, Rank.Two), Square.At(File.F, Rank.Two));
    private static (ISquare, ISquare) GetVertical() => (Square.At(File.B, Rank.Eight), Square.At(File.B, Rank.Five));

    private static (ISquare, ISquare) GetOffStraight() =>
        (Square.At(File.E, Rank.Eight), Square.At(File.F, Rank.Six));
}