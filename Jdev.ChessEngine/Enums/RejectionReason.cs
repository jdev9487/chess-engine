namespace Jdev.ChessEngine.Enums;

public enum RejectionReason
{
    MoveNotIntrinsic,
    MoveResultsInCheck,
    MoveBlocked,
    IllegalCastleAttempt
}