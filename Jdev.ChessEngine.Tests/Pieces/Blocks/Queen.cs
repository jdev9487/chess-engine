namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Queen(BlockTestModelQueen modelBase) : BlockMovesBase<ChessEngine.Pieces.Queen>(modelBase)
{
    public static readonly object[] Cases =
    [
        Blocks.Cases.Queen.North,
        Blocks.Cases.Queen.NorthEast,
        Blocks.Cases.Queen.East,
        Blocks.Cases.Queen.SouthEast,
        Blocks.Cases.Queen.South,
        Blocks.Cases.Queen.SouthWest,
        Blocks.Cases.Queen.West,
        Blocks.Cases.Queen.NorthWest,
        Blocks.Cases.Queen.Off
    ];
}