namespace Jdev.ChessEngine.Legislation;

using Enums;
using Pieces;
using Services;

public class Standard(IQuery query, IWorker worker) : BaseLegislator(query, worker)
{
    public override MoveResponse EnactMove(MoveRequest request)
    {
        if (!Query.IsDestinationIntrinsic(request.Destination, request.PieceToMove))
            return new MoveResponse(RejectionReason.MoveNotIntrinsic);

        if (Query.WouldRequestResultInCheck(request.Destination, request.PieceToMove))
            return new MoveResponse(RejectionReason.MoveResultsInCheck);

        if (Query.IsDestinationOccupied(request.Destination))
        {
            if (Query.IsPieceBlockedForCapture(request.Destination, request.PieceToMove))
                return new MoveResponse(RejectionReason.MoveBlocked);
            switch (Query.GetMoveType(request.Destination, request.PieceToMove))
            {
                case MoveType.Standard:
                    Worker.KillPiece(Query.PieceAt(request.Destination)!);
                    Worker.RelocatePiece(request.PieceToMove, request.Destination);
                    break;
                case MoveType.Promotion:
                    return new PromotionResponse(request, relocation: false);
                case MoveType.Castle:
                    return new MoveResponse(RejectionReason.IllegalCastleAttempt);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            if (Query.IsPieceBlockedForRelocation(request.Destination, request.PieceToMove))
                return new MoveResponse(RejectionReason.MoveBlocked);
            switch (Query.GetMoveType(request.Destination, request.PieceToMove))
            {
                case MoveType.Standard:
                    Worker.RelocatePiece(request.PieceToMove, request.Destination);
                    break;
                case MoveType.Promotion:
                    return new PromotionResponse(request, relocation: true);
                case MoveType.Castle:
                    if (Query.CanKingCastle((IKing)request.PieceToMove, request.Destination))
                        Worker.Castle((IKing)request.PieceToMove, request.Destination);
                    else return new MoveResponse(RejectionReason.IllegalCastleAttempt);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        return new MoveResponse(null);
    }

    public override MoveResponse Promote<T>(PromotionRequest<T> request)
    {
        if (request.Relocation)
            Worker.KillPiece(Query.PieceAt(request.Destination));
        Worker.KillPiece(request.PieceToMove);
        Worker.SpawnPiece<T>(request.Destination, request.PieceToMove.Colour);
        
        return new MoveResponse(null);
    }
}