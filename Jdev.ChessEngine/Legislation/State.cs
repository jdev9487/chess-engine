namespace Jdev.ChessEngine.Legislation;

using Enums;

public class State : IState
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