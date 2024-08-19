namespace Jdev.ChessEngine.Legislation;

using Enums;
using Pieces;
using Services;

public class Standard(IQuery query, IWorker worker) : BaseLegislator(query, worker)
{
    public override MoveResponse EnactMove(MoveRequest request)
    {
        var pieceToMove = PieceGroup.PieceAt(request.Origin);
        if (pieceToMove is null) return new MoveResponse(RejectionReason.NoPieceAtOrigin);
        if (!Query.IsDestinationIntrinsic(request.Destination, pieceToMove))
            return new MoveResponse(RejectionReason.MoveNotIntrinsic);

        if (Query.WouldRequestResultInCheck(request.Destination, pieceToMove))
            return new MoveResponse(RejectionReason.MoveResultsInCheck);

        if (Query.IsDestinationOccupied(request.Destination))
        {
            if (Query.IsPieceBlockedForCapture(request.Destination, pieceToMove))
                return new MoveResponse(RejectionReason.MoveBlocked);
            switch (Query.GetMoveType(request.Destination, pieceToMove))
            {
                case MoveType.Standard:
                    Worker.KillPiece(Query.PieceAt(request.Destination)!);
                    Worker.RelocatePiece(pieceToMove, request.Destination);
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
            if (Query.IsPieceBlockedForRelocation(request.Destination, pieceToMove))
                return new MoveResponse(RejectionReason.MoveBlocked);
            switch (Query.GetMoveType(request.Destination, pieceToMove))
            {
                case MoveType.Standard:
                    Worker.RelocatePiece(pieceToMove, request.Destination);
                    break;
                case MoveType.Promotion:
                    return new PromotionResponse(request, relocation: true);
                case MoveType.Castle:
                    if (Query.CanKingCastle((IKing)pieceToMove, request.Destination))
                        Worker.Castle((IKing)pieceToMove, request.Destination);
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
        var pieceToMove = PieceGroup.PieceAt(request.Origin);
        if (pieceToMove is null) return new MoveResponse(RejectionReason.NoPieceAtOrigin);
        if (request.Relocation)
            Worker.KillPiece(Query.PieceAt(request.Destination));
        Worker.KillPiece(pieceToMove);
        Worker.SpawnPiece<T>(request.Destination, pieceToMove.Colour);
        
        return new MoveResponse(null);
    }
}