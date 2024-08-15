namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Queen(BlockTestModel model) : BlockMovesBase<ChessEngine.Pieces.Queen>(model)
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