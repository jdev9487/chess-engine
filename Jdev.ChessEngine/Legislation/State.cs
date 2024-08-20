namespace Jdev.ChessEngine.Legislation;

using Enums;
using Pieces;

public class State(PieceGroup pieceGroup) : IState
{
    public bool ExpectingPromotion { get; set; }
    public void UpdateEnPassantStatus()
    {
        var pawns = pieceGroup.Pieces.Where(x => x is IPawn).Cast<IPawn>();
        foreach (var pawn in pawns) pawn.OpenToEnPassant = true;
    }

    public void FlipColourToMove()
    {
        ColourToMove = ColourToMove == Colour.White
            ? Colour.Black
            : Colour.White;
    }

    public Colour ColourToMove { get; private set; }
}