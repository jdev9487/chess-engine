namespace Jdev.ChessEngine.Models;

using Enums;

public class PromotionResponse(MoveRequest request, bool relocation) : MoveResponse(null)
{
    public PromotionRequest CreateSubsequentRequest(PieceType pieceType) =>
        new()
        {
            Relocation = relocation,
            PieceType = pieceType,
            Destination = request.Destination,
            PieceToMove = request.PieceToMove
        };
}