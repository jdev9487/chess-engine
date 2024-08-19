namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Models;

using ChessEngine.Pieces;

public class IntrinsicTestModelKing : IntrinsicTestModelBase<King>
{
    public override King CreatePiece()
    {
        return new King
        {
            Colour = Colour.GetValueOrDefault(),
            HasMoved = HasMoved,
            Position = StartingLocation
        };
    }
}