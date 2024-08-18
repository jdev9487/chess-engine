namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Models;

public class BlockTestModelKing : BlockTestModelBase<ChessEngine.Pieces.King>
{
    public override ChessEngine.Pieces.King CreatePiece() => new()
        {
            Colour = Colour.GetValueOrDefault(),
            Position = Origin,
            HasMoved = HasMoved
        };
}