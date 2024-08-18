namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class King(BlockTestModelKing modelBase) : BlockMovesBase<ChessEngine.Pieces.King>(modelBase)
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