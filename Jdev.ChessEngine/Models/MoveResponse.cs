namespace Jdev.ChessEngine.Models;

using Enums;

public class MoveResponse (RejectionReason? rejectionReason)
{
    public bool Success => rejectionReason is not null;
}