namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Bishop(BlockTestModelBishop modelBase) : BlockMovesBase<ChessEngine.Pieces.Bishop>(modelBase)
{
    public static readonly object[] Cases =
    [
        Blocks.Cases.Bishop.NorthEast,
        Blocks.Cases.Bishop.SouthEast,
        Blocks.Cases.Bishop.SouthWest,
        Blocks.Cases.Bishop.NorthWest,
        Blocks.Cases.Bishop.OffDiagonal
    ];
}