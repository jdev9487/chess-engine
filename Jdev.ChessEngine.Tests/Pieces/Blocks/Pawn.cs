namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Pawn(BlockTestModel model) : BlockMovesBase<ChessEngine.Pieces.Pawn>(model)
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