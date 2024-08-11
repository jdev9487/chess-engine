namespace Jdev.ChessEngine.Models;

using Enums;

public class Square
{
    private static Dictionary<Rank, Dictionary<File, Square>>? _squares;
    
    private Square() { }

    public Rank Rank { get; init; }
    public File File { get; init; }

    public static Square At(File file, Rank rank)
    {
        _squares ??= new Dictionary<Rank, Dictionary<File, Square>>();
        if (!_squares.ContainsKey(rank)) _squares.Add(rank, new Dictionary<File, Square>());
        if (!_squares[rank].ContainsKey(file)) _squares[rank].Add(file, new Square { Rank = rank, File = file });
        return _squares[rank][file];
    }

    public IEnumerable<Square> GetEnclosingRank() => Enum.GetValues<File>().Select(f => At(f, Rank));
    public IEnumerable<Square> GetEnclosingFile() => Enum.GetValues<Rank>().Select(r => At(File, r));
    public IEnumerable<Square> GetEnclosingPositiveDiagonal()
    {
        var k = (int)Rank - (int)File;
        return Enum.GetValues<File>()
            .Where(file => (int)file + k is <= (int)Rank.Eight and >= (int)Rank.One)
            .Select(file => At(file, (Rank)(int)file + k)).ToList();
    }
    public IEnumerable<Square> GetEnclosingNegativeDiagonal()
    {
        var k = (int)Rank + (int)File;
        return Enum.GetValues<File>()
            .Where(file => k - (int)file is <= (int)File.H and >= (int)File.A)
            .Select(file => At(file, k - (Rank)(int)file)).ToList();
    }
}