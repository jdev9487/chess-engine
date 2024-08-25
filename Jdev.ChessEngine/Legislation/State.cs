namespace Jdev.ChessEngine.Legislation;

using Enums;
using Pieces;

public class State(PieceGroup pieceGroup) : IState
{
    public bool ExpectingPromotion { get; set; }

    public void FlipColourToMove()
    {
        ColourToMove = ColourToMove == Colour.White
            ? Colour.Black
            : Colour.White;
    }

    public Colour ColourToMove { get; private set; }
}