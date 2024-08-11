namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Queen(IntrinsicTestModel model) : IntrinsicMovesBase<ChessEngine.Pieces.Queen>(model)
{
    public static readonly object[] Cases =
    [
        Intrinsic.Cases.Queen.NotOnBorder
    ];
}