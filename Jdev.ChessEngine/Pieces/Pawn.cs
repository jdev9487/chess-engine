namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class Pawn : BasePiece, IPawn
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations()
    {
        return IsOnPenultimateRank
            ? [new MoveProposition { Target = GetStandardForwardRelocate, SubsequentMove = MoveType.Promotion }]
            : HasMoved
                ? [new MoveProposition { Target = GetStandardForwardRelocate, SubsequentMove = MoveType.Standard }]
                :
                [
                    new MoveProposition { Target = GetStandardForwardRelocate, SubsequentMove = MoveType.Standard },
                    new MoveProposition { Target = GetInitialExtendedRelocate, SubsequentMove = MoveType.Standard }
                ];
    }

    public override IEnumerable<MoveProposition> GetIntrinsicCaptures()
    {
        var captures = new List<MoveProposition>();
        var fileToLeft = Position.File - 1;
        var fileToRight = Position.File + 1;
        if (fileToLeft is not null) captures.Add(new MoveProposition
        {
            Target = Square.At(fileToLeft, (Colour == Colour.White ? Position.Rank + 1 : Position.Rank - 1)!),
            SubsequentMove = IsOnPenultimateRank ? MoveType.Promotion : MoveType.Standard
        });
        if (fileToRight is not null) captures.Add(new MoveProposition
        {
            Target = Square.At(fileToRight, (Colour == Colour.White ? Position.Rank + 1 : Position.Rank - 1)!),
            SubsequentMove = IsOnPenultimateRank ? MoveType.Promotion : MoveType.Standard
        });
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
        .Select(mp => mp.Target)
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

    public bool HasMoved { get; set; }
    public bool OpenToEnPassant { get; set; }
}