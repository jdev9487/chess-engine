namespace Jdev.ChessEngine.Board;

public interface ISquare
{
    public Rank Rank { get; }
    public File File { get; }
    public IEnumerable<ISquare> GetEnclosingRank();
    public IEnumerable<ISquare> GetEnclosingFile();
    public IEnumerable<ISquare> GetEnclosingPositiveDiagonal();
    public IEnumerable<ISquare> GetEnclosingNegativeDiagonal();
    public IEnumerable<ISquare> GetDiagonalsInBetween(ISquare destination);
    public IEnumerable<ISquare> GetStraightsInBetween(ISquare destination);
    public bool IsTouching(ISquare destination);
}