namespace Jdev.ChessEngine.Legislation;

using Enums;

public class PromotionResponse(MoveRequest request, bool relocation) : MoveResponse(null)
{
    public override PromotionRequest CreateSubsequentRequest() =>
        new()
        {
            Relocation = relocation,
            Destination = request.Destination,
            Origin = request.Origin
        };

    public override bool PromotionNecessary => true;
}

public class StandardResponse(RejectionReason? rejectionReason) : MoveResponse(rejectionReason)
{
    public override PromotionRequest? CreateSubsequentRequest() => null;

    public override bool PromotionNecessary => false;
}
