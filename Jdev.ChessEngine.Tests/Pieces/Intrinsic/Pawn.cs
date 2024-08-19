namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic;

using Enums;
using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Pawn(IntrinsicTestModelPawn model) : IntrinsicMovesBase<ChessEngine.Pieces.Pawn>(model)
{
    public static readonly object[] Cases =
    [
        Intrinsic.Cases.Pawn.OnStartingRankOnAFile(Colour.White),
        Intrinsic.Cases.Pawn.OnStartingRankOnHFile(Colour.White),
        Intrinsic.Cases.Pawn.OnStartingRankNotOnEdge(Colour.White),
        Intrinsic.Cases.Pawn.NotOnStartingRankOnAFile(Colour.White),
        Intrinsic.Cases.Pawn.NotOnStartingRankOnHFile(Colour.White),
        Intrinsic.Cases.Pawn.NotOnStartingRankNotOnEdge(Colour.White)
    ];
}