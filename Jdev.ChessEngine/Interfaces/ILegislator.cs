namespace Jdev.ChessEngine.Interfaces;

using Models;

public interface ILegislator
{
    PieceGroup PieceGroup { get; }
    MoveResponse EnactMove(MoveRequest request);
    MoveResponse Promote(PromotionRequest request);
}