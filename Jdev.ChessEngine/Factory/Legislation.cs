namespace Jdev.ChessEngine.Factory;

using Interfaces;

public class Legislation
{
    public ILegislator Legislator { get; init; } = default!;
    public IQuery Query { get; init; } = default!;
    public IWorker Worker { get; init; } = default!;
}