namespace Jdev.ChessEngine.Enums;

public enum RejectionReason
{
    UnresolvedCheck,
    MoveNotIntrinsic,
    MoveResultsInCheck,
    MoveBlocked,
    IllegalCastleAttempt
}