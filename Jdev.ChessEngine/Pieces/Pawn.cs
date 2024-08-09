namespace Jdev.ChessEngine.Pieces;

using Enums;
using Models;
using Interfaces;

public class Pawn : BasePiece, IPiece
{
    public IEnumerable<MoveProposition> GetIntrinsicRelocations()
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

    public IEnumerable<MoveProposition> GetIntrinsicCaptures()
    {
        return Array.Empty<MoveProposition>();
    }

    public List<Square> GetPotentialBlocks(Square destination)
    {
        throw new NotImplementedException();
    }

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
        Colour.White => Square.At(Position.File, (Rank)((int)Position.Rank + 1)),
        Colour.Black => Square.At(Position.File, (Rank)((int)Position.Rank - 1)),
        _ => throw new ArgumentOutOfRangeException()
    };

    private Square GetInitialExtendedRelocate => Colour switch
    {
        Colour.White => Square.At(Position.File, Rank.Four),
        Colour.Black => Square.At(Position.File, Rank.Five),
        _ => throw new ArgumentOutOfRangeException()
    };
}