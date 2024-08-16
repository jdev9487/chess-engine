namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Knight(BlockTestModel model) : BlockMovesBase<ChessEngine.Pieces.Knight>(model)
{
    public static readonly object[] Cases =
    [
        Blocks.Cases.Knight.NorthEast,
        Blocks.Cases.Knight.EastNorth,
        Blocks.Cases.Knight.EastSouth,
        Blocks.Cases.Knight.SouthEast,
        Blocks.Cases.Knight.SouthWest,
        Blocks.Cases.Knight.WestSouth,
        Blocks.Cases.Knight.WestNorth,
        Blocks.Cases.Knight.NorthWest,
        Blocks.Cases.Knight.NotAMove
    ];
}