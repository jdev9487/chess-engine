namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Bishop(BlockTestModel model) : BlockMovesBase<ChessEngine.Pieces.Bishop>(model)
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