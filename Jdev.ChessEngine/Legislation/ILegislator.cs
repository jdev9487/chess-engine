namespace Jdev.ChessEngine.Legislation;

using Pieces;

public interface ILegislator
{
    MoveResponse EnactMove(MoveRequest request);
    MoveResponse Promote<T>(PromotionRequest<T> request) where T : BasePiece, new();
}