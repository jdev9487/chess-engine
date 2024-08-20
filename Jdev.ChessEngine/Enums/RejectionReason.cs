namespace Jdev.ChessEngine.Enums;

public enum RejectionReason
{
    IncorrectColour,
    MoveNotIntrinsic,
    MoveResultsInCheck,
    MoveBlocked,
    IllegalCastleAttempt,
    IllegalEnPassantAttempt,
    NoPieceAtOrigin,
    PromotionExpected,
    PromotionNotExpected
}