namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Rook(IntrinsicTestModel model) : IntrinsicMovesBase<ChessEngine.Pieces.Rook>(model)
{
    public static readonly object[] Cases =
    [
        Intrinsic.Cases.Rook.NotOnBorder,
        Intrinsic.Cases.Rook.OnBottomBorder,
        Intrinsic.Cases.Rook.OnRightBorder,
        Intrinsic.Cases.Rook.OnTopBorder,
        Intrinsic.Cases.Rook.OnLeftBorder,
        Intrinsic.Cases.Rook.OnA1,
        Intrinsic.Cases.Rook.OnA8,
        Intrinsic.Cases.Rook.OnH8,
        Intrinsic.Cases.Rook.OnH1
    ];
}