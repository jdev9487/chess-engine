namespace Jdev.ChessEngine.Factory;

using ChessEngine.Legislation;
using Services;

public class Legislation
{
    public ILegislator Legislator { get; init; } = default!;
    public IQuery Query { get; init; } = default!;
    public IWorker Worker { get; init; } = default!;
}