namespace Jdev.ChessEngine.Tests.Query.MoveType.Cases;

using Board;
using Enums;
using Models;
using ChessEngine.Pieces;

public static partial class EnPassant
{
    public static class NoDueToNoPawnToTake
    {
        public static EnPassantTestModel WhiteAttempts =>
            new()
            {
                PawnToCapture = new Pawn { Colour = Colour.White, Position = Square.At(File.E, Rank.Five) },
                Destination = Square.At(File.F, Rank.Six),
                PieceToBeCaptured = new Bishop
                    { Colour = Colour.Black, Position = Square.At(File.F, Rank.Five) }
            };

        public static EnPassantTestModel BlackAttempts =>
            new()
            {
                PawnToCapture = new Pawn { Colour = Colour.Black, Position = Square.At(File.E, Rank.Four) },
                Destination = Square.At(File.F, Rank.Three),
                PieceToBeCaptured = new Bishop
                    { Colour = Colour.Black, Position = Square.At(File.F, Rank.Four) }
            };
    }
}