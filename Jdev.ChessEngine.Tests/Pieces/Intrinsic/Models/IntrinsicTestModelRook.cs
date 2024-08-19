namespace Jdev.ChessEngine.Tests.Pieces.Intrinsic.Models;

using ChessEngine.Pieces;

public class IntrinsicTestModelRook : IntrinsicTestModelBase<Rook>
{
    public override Rook CreatePiece()
    {
        return new Rook
        {
            Colour = Colour.GetValueOrDefault(),
            Position = StartingLocation
        };
    }
}