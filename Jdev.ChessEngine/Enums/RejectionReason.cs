namespace Jdev.ChessEngine.Enums;

public enum RejectionReason
{
    MoveNotIntrinsic,
    MoveResultsInCheck,
    MoveBlocked,
    IllegalCastleAttempt,
    NoPieceAtOrigin,
    PromotionExpected,
    PromotionNotExpected
}