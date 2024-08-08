namespace Jdev.ChessEngine.Models;

using Enums;

public class PromotionResponse(MoveRequest request, bool relocation) : MoveResponse(null)
{
    public PromotionRequest CreateSubsequentRequest(PromotionType promotionType) =>
        new()
        {
            Relocation = relocation,
            PromotionType = promotionType,
            Destination = request.Destination,
            PieceToMove = request.PieceToMove
        };
}