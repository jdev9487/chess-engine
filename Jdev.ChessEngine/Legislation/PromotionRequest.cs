namespace Jdev.ChessEngine.Legislation;

using Enums;
using Pieces;

public class PromotionRequest<T> : MoveRequest where T : BasePiece, new()
{
    public PieceType PieceType { get; init; }
    public bool Relocation { get; init; }
}