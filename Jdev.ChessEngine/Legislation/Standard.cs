namespace Jdev.ChessEngine.Legislation;

using Enums;
using Pieces;
using Services;

public class Standard(IQuery query, IWorker worker, IState state) : BaseLegislator(query, worker)
{
    public override MoveResponse EnactMove(MoveRequest request)
    {
        if (state.ExpectingPromotion) return new StandardResponse(RejectionReason.PromotionExpected);
        var pieceToMove = PieceGroup.PieceAt(request.Origin);
        if (pieceToMove is null) return new StandardResponse(RejectionReason.NoPieceAtOrigin);
        if (!Query.IsDestinationIntrinsic(request.Destination, pieceToMove))
            return new StandardResponse(RejectionReason.MoveNotIntrinsic);

        if (Query.WouldRequestResultInCheck(request.Destination, pieceToMove))
            return new StandardResponse(RejectionReason.MoveResultsInCheck);

        if (Query.IsDestinationOccupied(request.Destination))
        {
            if (Query.IsPieceBlockedForCapture(request.Destination, pieceToMove))
                return new StandardResponse(RejectionReason.MoveBlocked);
            switch (Query.GetMoveType(request.Destination, pieceToMove))
            {
                case MoveType.Standard:
                    Worker.KillPiece(Query.PieceAt(request.Destination)!);
                    Worker.RelocatePiece(pieceToMove, request.Destination);
                    break;
                case MoveType.Promotion:
                    state.ExpectingPromotion = true;
                    return new PromotionResponse(request, relocation: false);
                case MoveType.Castle:
                    return new StandardResponse(RejectionReason.IllegalCastleAttempt);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            if (Query.IsPieceBlockedForRelocation(request.Destination, pieceToMove))
                return new StandardResponse(RejectionReason.MoveBlocked);
            switch (Query.GetMoveType(request.Destination, pieceToMove))
            {
                case MoveType.Standard:
                    Worker.RelocatePiece(pieceToMove, request.Destination);
                    break;
                case MoveType.Promotion:
                    state.ExpectingPromotion = true;
                    return new PromotionResponse(request, relocation: true);
                case MoveType.Castle:
                    if (Query.CanKingCastle((IKing)pieceToMove, request.Destination))
                        Worker.Castle((IKing)pieceToMove, request.Destination);
                    else return new StandardResponse(RejectionReason.IllegalCastleAttempt);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        return new StandardResponse(null);
    }

    public override StandardResponse Promote<T>(PromotionRequest request)
    {
        if (!state.ExpectingPromotion) return new StandardResponse(RejectionReason.PromotionNotExpected);
        var pieceToMove = PieceGroup.PieceAt(request.Origin);
        if (pieceToMove is null) return new StandardResponse(RejectionReason.NoPieceAtOrigin);
        if (!request.Relocation)
            Worker.KillPiece(Query.PieceAt(request.Destination)!);
        Worker.KillPiece(pieceToMove);
        Worker.SpawnPiece<T>(request.Destination, pieceToMove.Colour);

        state.ExpectingPromotion = false;
        return new StandardResponse(null);
    }
}