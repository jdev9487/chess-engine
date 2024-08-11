namespace Jdev.ChessEngine.Models;

public class Rank : Axis<Rank>
{
    public static Rank One => GetAxis(1);
    public static Rank Two => GetAxis(2);
    public static Rank Three => GetAxis(3);
    public static Rank Four => GetAxis(4);
    public static Rank Five => GetAxis(5);
    public static Rank Six => GetAxis(6);
    public static Rank Seven => GetAxis(7);
    public static Rank Eight => GetAxis(8);

    protected override string Display => Coordinate switch
    {
        1 => "1",
        2 => "2",
        3 => "3",
        4 => "4",
        5 => "5",
        6 => "6",
        7 => "7",
        8 => "8",
        _ => throw new ArgumentException()
    };
}