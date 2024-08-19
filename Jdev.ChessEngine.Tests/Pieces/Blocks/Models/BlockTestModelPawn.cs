namespace Jdev.ChessEngine.Tests.Pieces.Blocks.Models;

public class BlockTestModelPawn : BlockTestModelBase<ChessEngine.Pieces.Pawn>
{
    public override ChessEngine.Pieces.Pawn CreatePiece() => new()
        {
            Colour = Colour.GetValueOrDefault(),
            HasMoved = HasMoved,
            Position = Origin
        };
}