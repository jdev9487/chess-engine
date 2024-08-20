namespace Jdev.ChessEngine.Legislation;

using Enums;

public interface IState
{
    bool ExpectingPromotion { get; set; }
    void UpdateEnPassantStatus();
    Colour ColourToMove { get; set; }
}