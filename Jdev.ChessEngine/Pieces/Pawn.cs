namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class Pawn : BasePiece, IPawn
{
    public override IEnumerable<ISquare> GetIntrinsicRelocations()
    {
        return IsOnPenultimateRank
            ? [GetStandardForwardRelocate]
            : HasMoved
                ? [GetStandardForwardRelocate]
                :
                [
                    GetStandardForwardRelocate,
                    GetInitialExtendedRelocate
                ];
    }

    public override IEnumerable<ISquare> GetIntrinsicCaptures()
    {
        var captures = new List<ISquare>();
        var fileToLeft = Position.File - 1;
        var fileToRight = Position.File + 1;
        if (fileToLeft is not null)
            captures.Add(Square.At(fileToLeft, (Colour == Colour.White ? Position.Rank + 1 : Position.Rank - 1)!));
        if (fileToRight is not null)
            captures.Add(Square.At(fileToRight, (Colour == Colour.White ? Position.Rank + 1 : Position.Rank - 1)!));
        return captures;
    }

    public override IEnumerable<ISquare> GetPotentialRelocationBlocks(ISquare destination)
    {
        var vib = Position.GetVerticalsInBetween(destination)
            .Where(s => s != Position)
            .ToArray();
        return HasMoved switch
        {
            true when vib.Length == 1 => vib,
            false when vib.Length <= 2 => vib,
            _ => []
        };
    }

    public override IEnumerable<ISquare> GetPotentialCaptureBlocks(ISquare destination) => GetIntrinsicCaptures()
        .Where(s => s == destination);

    public override object Clone() => CloneObject<Pawn>();

    private bool IsOnPenultimateRank => Colour switch
    {
        Colour.White => Position.Rank == Rank.Seven,
        Colour.Black => Position.Rank == Rank.Two,
        _ => throw new ArgumentOutOfRangeException()
    };

    private ISquare GetStandardForwardRelocate => Colour switch
    {
        Colour.White => Square.At(Position.File, (Position.Rank + 1)!),
        Colour.Black => Square.At(Position.File, (Position.Rank - 1)!),
        _ => throw new ArgumentOutOfRangeException()
    };

    private ISquare GetInitialExtendedRelocate => Colour switch
    {
        Colour.White => Square.At(Position.File, Rank.Four),
        Colour.Black => Square.At(Position.File, Rank.Five),
        _ => throw new ArgumentOutOfRangeException()
    };

    public override string ToString() => Colour switch
    {
        Colour.White => "♙",
        Colour.Black => "♟",
        _ => throw new ArgumentOutOfRangeException()
    };

    public bool HasMoved { get; init; }
    public bool OpenToEnPassant { get; set; }
}