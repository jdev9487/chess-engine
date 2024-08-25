namespace Jdev.ChessEngine.Tests.Query.MoveType.Cases;

using Board;
using Enums;
using Models;
using ChessEngine.Pieces;

public static partial class EnPassant
{
    public static class Yes
    {
        public static EnPassantTestModel WhiteCapturesToTheRight =>
            new()
            {
                PawnToCapture = new Pawn { Colour = Colour.White, Position = Square.At(File.E, Rank.Five) },
                Destination = Square.At(File.F, Rank.Six),
                PieceToBeCaptured = new Pawn
                    { Colour = Colour.Black, Position = Square.At(File.F, Rank.Five), OpenToEnPassant = true }
            };

        public static EnPassantTestModel WhiteCapturesToTheLeft =>
            new()
            {
                PawnToCapture = new Pawn { Colour = Colour.White, Position = Square.At(File.E, Rank.Five) },
                Destination = Square.At(File.D, Rank.Six),
                PieceToBeCaptured = new Pawn
                    { Colour = Colour.Black, Position = Square.At(File.D, Rank.Five), OpenToEnPassant = true }
            };

        public static EnPassantTestModel BlackCapturesToTheRight =>
            new()
            {
                PawnToCapture = new Pawn { Colour = Colour.Black, Position = Square.At(File.E, Rank.Four) },
                Destination = Square.At(File.F, Rank.Three),
                PieceToBeCaptured = new Pawn
                    { Colour = Colour.White, Position = Square.At(File.F, Rank.Four), OpenToEnPassant = true }
            };

        public static EnPassantTestModel BlackCapturesToTheLeft =>
            new()
            {
                PawnToCapture = new Pawn { Colour = Colour.Black, Position = Square.At(File.E, Rank.Four) },
                Destination = Square.At(File.D, Rank.Three),
                PieceToBeCaptured = new Pawn
                    { Colour = Colour.White, Position = Square.At(File.D, Rank.Four), OpenToEnPassant = true }
            };
    }
}