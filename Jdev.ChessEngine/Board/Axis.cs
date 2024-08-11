namespace Jdev.ChessEngine.Board;

public abstract class Axis<TAxis> where TAxis : Axis<TAxis>, new()
{
    private const int MinValue = 1;
    private const int MaxValue = 8;
    
    private static Dictionary<int, TAxis>? _axes;

    public int Coordinate { get; private init; }

    protected static TAxis GetAxis(int value)
    {
        {
            _axes ??= new Dictionary<int, TAxis>();
            if (!_axes.ContainsKey(value)) _axes.Add(value, new TAxis { Coordinate = value });
            return _axes[value];
        }
    }

    public static IEnumerable<TAxis> Enumerate => Enumerable.Range(1, 8).Select(GetAxis);

    public static TAxis At(int coordinate) => GetAxis(coordinate);
    
    public int Inc => Coordinate == MaxValue ? Coordinate : Coordinate + 1;
    public int Dec => Coordinate == MinValue ? Coordinate : Coordinate - 1;

    protected abstract string Display { get; }
    public override string ToString() => Display;
}