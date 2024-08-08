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
}