namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Rook(BlockTestModel model) : BlockMovesBase<ChessEngine.Pieces.Rook>(model)
{
    public static readonly object[] Cases =
    [
        Blocks.Cases.Rook.North,
        Blocks.Cases.Rook.East,
        Blocks.Cases.Rook.South,
        Blocks.Cases.Rook.West,
        Blocks.Cases.Rook.Off
    ];
}