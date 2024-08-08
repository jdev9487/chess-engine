namespace Jdev.ChessEngine.Interfaces;

using Models;

public interface ILegislator
{
    MoveResponse EnactMove(MoveRequest request);
    MoveResponse Promote(PromotionRequest request);
}