namespace Jdev.ChessEngine.Models;

using Enums;
using Pieces;

public class PromotionResponse(MoveRequest request, bool relocation) : MoveResponse(null)
{
    public PromotionRequest<T> CreateSubsequentRequest<T>(PieceType pieceType) where T : BasePiece, new() =>
        new()
        {
            Relocation = relocation,
            PieceType = pieceType,
            Destination = request.Destination,
            PieceToMove = request.PieceToMove
        };
}