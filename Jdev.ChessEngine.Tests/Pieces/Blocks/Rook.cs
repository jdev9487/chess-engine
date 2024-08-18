namespace Jdev.ChessEngine.Tests.Pieces.Blocks;

using Models;

[TestFixture]
[TestFixtureSource(nameof(Cases))]
public class Rook(BlockTestModelRook modelBase) : BlockMovesBase<ChessEngine.Pieces.Rook>(modelBase)
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