namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class Pawn : BasePiece
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

    public override List<Square> GetPotentialBlocks(Square destination)
    {
        throw new NotImplementedException();
    }
    
    public override object Clone() => CloneObject<Pawn>();

    private bool HasMoved => Colour switch
    {
        Colour.White => Position.Rank != Rank.Two,
        Colour.Black => Position.Rank != Rank.Seven,
        _ => throw new ArgumentOutOfRangeException()
    };

    private bool IsOnPenultimateRank => Colour switch
    {
        Colour.White => Position.Rank == Rank.Seven,
        Colour.Black => Position.Rank == Rank.Two,
        _ => throw new ArgumentOutOfRangeException()
    };

    private Square GetStandardForwardRelocate => Colour switch
    {
        Colour.White => Square.At(Position.File, (Position.Rank + 1)!),
        Colour.Black => Square.At(Position.File, (Position.Rank - 1)!),
        _ => throw new ArgumentOutOfRangeException()
    };

    private Square GetInitialExtendedRelocate => Colour switch
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
}