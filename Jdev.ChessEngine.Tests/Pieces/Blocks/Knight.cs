namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Knight(BlockTestModel model) : BlockMovesBase<ChessEngine.Pieces.Knight>(model)
{
    public static readonly object[] Cases =
    [
        Blocks.Cases.Knight.NorthEast
    ];
}