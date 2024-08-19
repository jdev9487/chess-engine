namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Models;

using ChessEngine.Pieces;

public class IntrinsicTestModelPawn : IntrinsicTestModelBase<Pawn>
{
    public override Pawn CreatePiece()
    {
        return new Pawn
        {
            Colour = Colour.GetValueOrDefault(),
            HasMoved = HasMoved,
            Position = StartingLocation
        };
    }
}