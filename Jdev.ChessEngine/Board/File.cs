namespace Jdev.ChessEngine.Board;

public class File : Axis<File>
{
    public static File A => GetAxis(1);
    public static File B => GetAxis(2);
    public static File C => GetAxis(3);
    public static File D => GetAxis(4);
    public static File E => GetAxis(5);
    public static File F => GetAxis(6);
    public static File G => GetAxis(7);
    public static File H => GetAxis(8);

    protected override string Display => Coordinate switch
    {
        1 => "A",
        2 => "B",
        3 => "C",
        4 => "D",
        5 => "E",
        6 => "F",
        7 => "G",
        8 => "H",
        _ => throw new ArgumentException()
    };
}