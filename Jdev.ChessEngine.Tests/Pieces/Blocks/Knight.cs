namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Knight(BlockTestModelKnight modelBase) : BlockMovesBase<ChessEngine.Pieces.Knight>(modelBase)
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