namespace Jdev.ChessEngine.Legislation;

using Enums;

public class MoveResponse (RejectionReason? rejectionReason)
{
    public bool Success => rejectionReason is null;
    public RejectionReason? RejectionReason => rejectionReason;
}