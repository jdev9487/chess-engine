namespace Jdev.ChessEngine.Legislation;

using Enums;

public abstract class MoveResponse (RejectionReason? rejectionReason)
{
    public bool Success => rejectionReason is null;
    public RejectionReason? RejectionReason => rejectionReason;
    public abstract bool PromotionNecessary { get; }
    public abstract PromotionRequest? CreateSubsequentRequest();
}