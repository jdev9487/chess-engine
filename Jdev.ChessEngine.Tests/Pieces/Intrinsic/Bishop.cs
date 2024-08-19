namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Bishop(IntrinsicTestModelBishop model) : IntrinsicMovesBase<ChessEngine.Pieces.Bishop>(model)
{
    public static readonly object[] Cases =
    [
        Intrinsic.Cases.Bishop.NotOnBorder,
        Intrinsic.Cases.Bishop.OnBottomBorder,
        Intrinsic.Cases.Bishop.OnRightBorder,
        Intrinsic.Cases.Bishop.OnTopBorder,
        Intrinsic.Cases.Bishop.OnLeftBorder,
        Intrinsic.Cases.Bishop.OnA1,
        Intrinsic.Cases.Bishop.OnA8,
        Intrinsic.Cases.Bishop.OnH8,
        Intrinsic.Cases.Bishop.OnH1
    ];
}