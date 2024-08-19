namespace Jdev.ChessEngine.Legislation;

using Enums;

public class State : IState
{
    public bool ExpectingPromotion { get; set; }
    public Colour ColourToMove { get; set; }
}