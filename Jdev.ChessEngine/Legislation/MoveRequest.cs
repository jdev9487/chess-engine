namespace Jdev.ChessEngine.Legislation;

using Board;

public class MoveRequest
{
    public ISquare Origin { get; init; } = default!;
    public ISquare Destination { get; init; } = default!;
}