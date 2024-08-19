namespace Jdev.ChessEngine.Legislation;

using Enums;
using Pieces;

public class PromotionResponse(MoveRequest request, bool relocation) : MoveResponse(null)
{
    public PromotionRequest<T> CreateSubsequentRequest<T>(PieceType pieceType) where T : IPiece, new() =>
        new()
        {
            Relocation = relocation,
            PieceType = pieceType,
            Destination = request.Destination,
            Origin = request.Origin
        };
}