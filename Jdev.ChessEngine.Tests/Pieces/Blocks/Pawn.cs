namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Pawn(BlockTestModelPawn modelBase) : BlockMovesBase<ChessEngine.Pieces.Pawn>(modelBase)
{
    public static readonly object[] Cases =
    [
        Blocks.Cases.Pawn.WhiteInitialOne,
        Blocks.Cases.Pawn.WhiteInitialTwo,
        Blocks.Cases.Pawn.WhiteOne,
        Blocks.Cases.Pawn.WhiteTwo,
        Blocks.Cases.Pawn.WhiteStandardCaptureLeft,
        Blocks.Cases.Pawn.WhiteStandardCaptureRight,
        Blocks.Cases.Pawn.WhiteOff,
        Blocks.Cases.Pawn.BlackInitialOne,
        Blocks.Cases.Pawn.BlackInitialTwo,
        Blocks.Cases.Pawn.BlackOne,
        Blocks.Cases.Pawn.BlackTwo,
        Blocks.Cases.Pawn.BlackStandardCaptureLeft,
        Blocks.Cases.Pawn.BlackStandardCaptureRight,
        Blocks.Cases.Pawn.BlackOff
    ];
}