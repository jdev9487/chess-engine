namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Models;

using ChessEngine.Pieces;

public class IntrinsicTestModelQueen : IntrinsicTestModelBase<Queen>
{
    public override Queen CreatePiece()
    {
        return new Queen
        {
            Colour = Colour.GetValueOrDefault(),
            Position = StartingLocation
        };
    }
}