namespace Jdev.ChessEngine.Interfaces;

using Enums;
using Models;

public interface ILegislator
{
    MoveResponse EnactMove(MoveRequest request);
    MoveResponse Promote(PromotionRequest request);
}