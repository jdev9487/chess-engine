namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Models;

using ChessEngine.Pieces;

public class IntrinsicTestModelBishop : IntrinsicTestModelBase<Bishop>
{
    public override Bishop CreatePiece()
    {
        return new Bishop
        {
            Colour = Colour.GetValueOrDefault(),
            Position = StartingLocation
        };
    }
}