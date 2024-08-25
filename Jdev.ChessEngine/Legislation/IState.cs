namespace Jdev.ChessEngine.Legislation;

using Enums;

public interface IState
{
    bool ExpectingPromotion { get; set; }
    void FlipColourToMove();
    Colour ColourToMove { get; }
}