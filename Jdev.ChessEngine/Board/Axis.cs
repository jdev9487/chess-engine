namespace Jdev.ChessEngine.Board;

public abstract class Axis<TAxis> where TAxis : Axis<TAxis>, new()
{
    private bool Equals(Axis<TAxis> other)
    {
        return Coordinate == other.Coordinate && Display == other.Display;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Axis<TAxis>)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Coordinate, Display);
    }

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

    public static TAxis? operator +(Axis<TAxis> axis, int step) =>
        axis.Coordinate + step > MaxValue || axis.Coordinate + step < MinValue
            ? null
            : GetAxis(axis.Coordinate + step);
    public static TAxis? operator -(Axis<TAxis> axis, int step) =>
        axis.Coordinate - step < MinValue || axis.Coordinate + step < MinValue
            ? null
            : GetAxis(axis.Coordinate - step);

    public static bool operator <(Axis<TAxis> a, Axis<TAxis> b) => a.Coordinate < b.Coordinate;
    public static bool operator <=(Axis<TAxis> a, Axis<TAxis> b) => a.Coordinate <= b.Coordinate;
    public static bool operator >(Axis<TAxis> a, Axis<TAxis> b) => a.Coordinate > b.Coordinate;
    public static bool operator >=(Axis<TAxis> a, Axis<TAxis> b) => a.Coordinate >= b.Coordinate;
    public static bool operator ==(Axis<TAxis> a, Axis<TAxis> b) => a.Coordinate == b.Coordinate;
    public static bool operator !=(Axis<TAxis> a, Axis<TAxis> b) => a.Coordinate != b.Coordinate;
    public static TAxis Min(Axis<TAxis> a, Axis<TAxis> b) => a <= b ? GetAxis(a.Coordinate) : GetAxis(b.Coordinate);
    public static TAxis Max(Axis<TAxis> a, Axis<TAxis> b) => a >= b ? GetAxis(a.Coordinate) : GetAxis(b.Coordinate);
    public static IEnumerable<TAxis> Enumerate => Enumerable.Range(1, 8).Select(GetAxis);
    public static int Distance(Axis<TAxis> a, Axis<TAxis> b) => Max(a, b).Coordinate - Min(a, b).Coordinate;

    public static TAxis At(int coordinate) => GetAxis(coordinate);
    
    public int Inc => Coordinate == MaxValue ? Coordinate : Coordinate + 1;
    public int Dec => Coordinate == MinValue ? Coordinate : Coordinate - 1;

    protected abstract string Display { get; }
    public override string ToString() => Display;
}