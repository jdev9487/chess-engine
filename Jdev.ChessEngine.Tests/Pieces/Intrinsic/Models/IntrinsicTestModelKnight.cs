namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Models;

using ChessEngine.Pieces;

public class IntrinsicTestModelKnight : IntrinsicTestModelBase<Knight>
{
    public override Knight CreatePiece()
    {
        return new Knight
        {
            Colour = Colour.GetValueOrDefault(),
            Position = StartingLocation
        };
    }
}