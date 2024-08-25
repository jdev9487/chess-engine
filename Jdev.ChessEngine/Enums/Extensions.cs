namespace Jdev.ChessEngine.Enums;

public static class Extensions
{
    public static Colour Not(this Colour colour) => colour == Colour.White
        ? Colour.Black
        : Colour.White;
}