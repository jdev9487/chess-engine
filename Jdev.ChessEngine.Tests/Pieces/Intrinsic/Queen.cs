namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Queen(IntrinsicTestModelQueen model) : IntrinsicMovesBase<ChessEngine.Pieces.Queen>(model)
{
    public static readonly object[] Cases =
    [
        Intrinsic.Cases.Queen.NotOnBorder,
        Intrinsic.Cases.Queen.OnBottomBorder,
        Intrinsic.Cases.Queen.OnRightBorder,
        Intrinsic.Cases.Queen.OnTopBorder,
        Intrinsic.Cases.Queen.OnLeftBorder,
        Intrinsic.Cases.Queen.OnA1,
        Intrinsic.Cases.Queen.OnA8,
        Intrinsic.Cases.Queen.OnH8,
        Intrinsic.Cases.Queen.OnH1
    ];
}