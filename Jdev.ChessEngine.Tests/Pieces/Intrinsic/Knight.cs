namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Knight(IntrinsicTestModelKnight model) : IntrinsicMovesBase<ChessEngine.Pieces.Knight>(model)
{
    public static readonly object[] Cases =
    [
        Intrinsic.Cases.Knight.InCenter,
        Intrinsic.Cases.Knight.OnG4,
        Intrinsic.Cases.Knight.OnD7,
        Intrinsic.Cases.Knight.OnB4,
        Intrinsic.Cases.Knight.OnD2,
        Intrinsic.Cases.Knight.OnG2,
        Intrinsic.Cases.Knight.OnG7,
        Intrinsic.Cases.Knight.OnB7,
        Intrinsic.Cases.Knight.OnB2,
        Intrinsic.Cases.Knight.OnH4,
        Intrinsic.Cases.Knight.OnA4,
        Intrinsic.Cases.Knight.OnD1,
        Intrinsic.Cases.Knight.OnD8,
        Intrinsic.Cases.Knight.OnA1,
        Intrinsic.Cases.Knight.OnA8,
        Intrinsic.Cases.Knight.OnH8,
        Intrinsic.Cases.Knight.OnH1
    ];
}