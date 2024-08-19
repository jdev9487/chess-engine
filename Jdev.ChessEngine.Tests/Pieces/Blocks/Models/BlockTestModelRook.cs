namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Models;

public class BlockTestModelRook : BlockTestModelBase<ChessEngine.Pieces.Rook>
{
    public override ChessEngine.Pieces.Rook CreatePiece() => new()
        {
            Colour = Colour.GetValueOrDefault(),
            Position = Origin,
            HasMoved = HasMoved
        };
}