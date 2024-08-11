namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class King(IntrinsicTestModel model) : IntrinsicMovesBase<ChessEngine.Pieces.King>(model)
{
    public static readonly object[] Cases =
    [
        Intrinsic.Cases.King.NotOnBorder
    ];
}