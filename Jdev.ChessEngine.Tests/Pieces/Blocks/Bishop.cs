namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Bishop(BlockTestModel model) : BlockMovesBase<ChessEngine.Pieces.Bishop>(model)
{
    public static readonly object[] Cases =
    [
        Blocks.Cases.Bishop.PositiveDiagonal,
        Blocks.Cases.Bishop.NegativeDiagonal,
        Blocks.Cases.Bishop.OffDiagonal
    ];
}