namespace Jdev.ChessEngine.Board;

public class Square
{
    private static Dictionary<Rank, Dictionary<File, Square>>? _squares;
    
    private Square() { }

    public Rank Rank { get; private init; } = default!;
    public File File { get; private init; } = default!;

    public static Square At(File file, Rank rank)
    {
        _squares ??= new Dictionary<Rank, Dictionary<File, Square>>();
        if (!_squares.ContainsKey(rank)) _squares.Add(rank, new Dictionary<File, Square>());
        if (!_squares[rank].ContainsKey(file)) _squares[rank].Add(file, new Square { Rank = rank, File = file });
        return _squares[rank][file];
    }

    public IEnumerable<Square> GetEnclosingRank() => File.Enumerate.Select(f => At(f, Rank));
    public IEnumerable<Square> GetEnclosingFile() => Rank.Enumerate.Select(r => At(File, r));
    public IEnumerable<Square> GetEnclosingPositiveDiagonal()
    {
        var k = Rank.Coordinate - File.Coordinate;
        return File.Enumerate
            .Where(file => file.Coordinate + k <= Rank.Eight.Coordinate && file.Coordinate + k >= Rank.One.Coordinate)
            .Select(file => At(file, Rank.At(file.Coordinate + k))).ToList();
    }
    public IEnumerable<Square> GetEnclosingNegativeDiagonal()
    {
        var k = Rank.Coordinate + File.Coordinate;
        return File.Enumerate
            .Where(file => k - file.Coordinate <= File.H.Coordinate && k - file.Coordinate >= File.A.Coordinate)
            .Select(file => At(file, Rank.At(k - file.Coordinate))).ToList();
    }
}