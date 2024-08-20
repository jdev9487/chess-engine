namespace Jdev.ChessEngine.Legislation;

using Enums;
using Pieces;

public class State(PieceGroup pieceGroup) : IState
{
    public bool ExpectingPromotion { get; set; }
    public void UpdateEnPassantStatus()
    {
        var pawns = pieceGroup.Pieces.Where(x => x is IPawn);
        foreach (IPawn pawn in pawns) pawn.OpenToEnPassant = true;
    }

    public Colour ColourToMove { get; set; }
}