namespace Jdev.ChessEngine.Models;

using Enums;

public class PromotionRequest : MoveRequest
{
    public PromotionType PromotionType { get; init; }
    public bool Relocation { get; init; }
}