namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Models;

public class BlockTestModelKnight : BlockTestModelBase<ChessEngine.Pieces.Knight>
{
    public override ChessEngine.Pieces.Knight CreatePiece() => new()
        {
            Colour = Colour.GetValueOrDefault(),
            Position = Origin
        };
}