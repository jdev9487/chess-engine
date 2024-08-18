namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Models;

public class BlockTestModelBishop : BlockTestModelBase<ChessEngine.Pieces.Bishop>
{
    public override ChessEngine.Pieces.Bishop CreatePiece() => new()
        {
            Colour = Colour.GetValueOrDefault(),
            Position = Origin
        };
}