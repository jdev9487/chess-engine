namespace Jdev.ChessEngine.Models;

using Enums;

public class PromotionRequest : MoveRequest
{
    public PieceType PieceType { get; init; }
    public bool Relocation { get; init; }
}