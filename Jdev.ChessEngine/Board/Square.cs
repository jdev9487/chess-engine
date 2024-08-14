namespace Jdev.ChessEngine.Board;

public class Square : ISquare
{
    private static Dictionary<Rank, Dictionary<File, ISquare>>? _squares;
    
    private Square() { }

    public Rank Rank { get; private init; } = default!;
    public File File { get; private init; } = default!;

    public static ISquare At(File file, Rank rank)
    {
        _squares ??= new Dictionary<Rank, Dictionary<File, ISquare>>();
        if (!_squares.ContainsKey(rank)) _squares.Add(rank, new Dictionary<File, ISquare>());
        if (!_squares[rank].ContainsKey(file)) _squares[rank].Add(file, new Square { Rank = rank, File = file });
        return _squares[rank][file];
    }

    public IEnumerable<ISquare> GetEnclosingRank() => File.Enumerate.Select(f => At(f, Rank));
    public IEnumerable<ISquare> GetEnclosingFile() => Rank.Enumerate.Select(r => At(File, r));
    public IEnumerable<ISquare> GetEnclosingPositiveDiagonal()
    {
        var k = Rank.Coordinate - File.Coordinate;
        return File.Enumerate
            .Where(file => file.Coordinate + k <= Rank.Eight.Coordinate && file.Coordinate + k >= Rank.One.Coordinate)
            .Select(file => At(file, Rank.At(file.Coordinate + k))).ToList();
    }
    public IEnumerable<ISquare> GetEnclosingNegativeDiagonal()
    {
        var k = Rank.Coordinate + File.Coordinate;
        return File.Enumerate
            .Where(file => k - file.Coordinate <= File.H.Coordinate && k - file.Coordinate >= File.A.Coordinate)
            .Select(file => At(file, Rank.At(k - file.Coordinate))).ToList();
    }

    public IEnumerable<ISquare> GetDiagonalsInBetween(ISquare destination)
    {
        var minFile = File.Min(File, destination.File);
        var maxFile = File.Max(File, destination.File);
        bool positive;
        if (Rank.Coordinate - File.Coordinate == destination.Rank.Coordinate - destination.File.Coordinate)
        {
            positive = true;
        }
        else if (Rank.Coordinate + File.Coordinate == destination.Rank.Coordinate + destination.File.Coordinate)
        {
            positive = false;
        }
        else return [];

        return (positive
                ? GetEnclosingPositiveDiagonal()
                : GetEnclosingNegativeDiagonal())
            .Where(s => s.File <= maxFile && s.File >= minFile);
    }

    public IEnumerable<ISquare> GetStraightsInBetween(ISquare destination)
    {
        var minFile = File.Min(File, destination.File);
        var maxFile = File.Max(File, destination.File);
        var minRank = Rank.Min(Rank, destination.Rank);
        var maxRank = Rank.Max(Rank, destination.Rank);
        bool vertical;
        if (File.Coordinate == destination.File.Coordinate) vertical = true;
        else if (Rank.Coordinate == destination.Rank.Coordinate) vertical = false;
        else return [];
        return vertical
            ? GetEnclosingFile().Where(s => s.File <= maxFile && s.File >= minFile)
            : GetEnclosingRank().Where(s => s.Rank <= maxRank && s.Rank >= minRank);
    }
}