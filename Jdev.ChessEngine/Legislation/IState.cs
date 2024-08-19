namespace Jdev.ChessEngine.Legislation;

using Enums;

public interface IState
{
    bool ExpectingPromotion { get; set; }
    Colour ColourToMove { get; set; }
}