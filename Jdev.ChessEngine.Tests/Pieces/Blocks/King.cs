namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class King(BlockTestModel model) : BlockMovesBase<ChessEngine.Pieces.King>(model)
{
    public static readonly object[] Cases =
    [
        Blocks.Cases.King.North,
        Blocks.Cases.King.NorthEast,
        Blocks.Cases.King.East,
        Blocks.Cases.King.SouthEast,
        Blocks.Cases.King.South,
        Blocks.Cases.King.SouthWest,
        Blocks.Cases.King.West,
        Blocks.Cases.King.NorthWest,
        Blocks.Cases.King.LongerThanOne
    ];
}