namespace Jdev.ChessEngine.Services;

using Enums;
using Models;
using Interfaces;
using Pieces;

public class Standard(IQuery query, IWorker worker) : ILegislator
{
    public MoveResponse EnactMove(MoveRequest request)
    {
        if (query.IsInCheck(request.PieceToMove.Colour))
        {
            if (!query.DoesRequestUncheckMover(request.Destination, request.PieceToMove))
                return new MoveResponse(RejectionReason.UnresolvedCheck);
        }

        if (!query.IsDestinationIntrinsic(request.Destination, request.PieceToMove))
            return new MoveResponse(RejectionReason.MoveNotIntrinsic);

        if (query.DoesRequestPlaceMoverInCheck(request.Destination, request.PieceToMove))
            return new MoveResponse(RejectionReason.MoveResultsInCheck);

        if (query.IsDestinationOccupied(request.Destination))
        {
            if (query.IsPieceBlockedForCapture(request.Destination, request.PieceToMove))
                return new MoveResponse(RejectionReason.MoveBlocked);
            switch (query.GetMoveType(request.Destination, request.PieceToMove))
            {
                case MoveType.Standard:
                    worker.KillPiece(query.PieceAt(request.Destination)!);
                    worker.RelocatePiece(request.PieceToMove, request.Destination);
                    break;
                case MoveType.Promotion:
                    return new PromotionResponse(request, relocation: false);
                default:
                case MoveType.Castle:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            if (query.IsPieceBlockedForRelocation(request.Destination, request.PieceToMove))
                return new MoveResponse(RejectionReason.MoveBlocked);
            switch (query.GetMoveType(request.Destination, request.PieceToMove))
            {
                case MoveType.Standard:
                    worker.RelocatePiece(request.PieceToMove, request.Destination);
                    break;
                case MoveType.Promotion:
                    return new PromotionResponse(request, relocation: true);
                case MoveType.Castle:
                    worker.Castle((King)request.PieceToMove, request.Destination);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        return new MoveResponse(null);
    }

    public MoveResponse Promote<T>(PromotionRequest<T> request) where T : BasePiece, new()
    {
        if (request.Relocation)
            worker.KillPiece(query.PieceAt(request.Destination));
        worker.KillPiece(request.PieceToMove);
        worker.SpawnPiece<T>(request.Destination, request.PieceToMove.Colour);
        
        return new MoveResponse(null);
    }
}