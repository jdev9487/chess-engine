namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class King(IntrinsicTestModel model) : IntrinsicMovesBase<ChessEngine.Pieces.King>(model)
{
    public static readonly object[] Cases =
    [
        Intrinsic.Cases.King.NotOnBorder,
        Intrinsic.Cases.King.OnRightBorder,
        Intrinsic.Cases.King.OnLeftBorder,
        Intrinsic.Cases.King.OnTopBorder,
        Intrinsic.Cases.King.OnBottomBorder,
        Intrinsic.Cases.King.OnA1,
        Intrinsic.Cases.King.OnH1,
        Intrinsic.Cases.King.OnH8,
        Intrinsic.Cases.King.OnA8
    ];
}