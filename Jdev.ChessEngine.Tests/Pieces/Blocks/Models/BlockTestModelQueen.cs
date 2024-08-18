namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Models;

public class BlockTestModelQueen : BlockTestModelBase<ChessEngine.Pieces.Queen>
{
    public override ChessEngine.Pieces.Queen CreatePiece() => new()
        {
            Colour = Colour.GetValueOrDefault(),
            Position = Origin
        };
}