namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class King : BasePiece
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations()
    {
        var standardMoves = GetMoves().Select(s => new MoveProposition
            { Target = s, SubsequentMove = MoveType.Standard });
        var castlingMoves = HasMoved
            ? Array.Empty<MoveProposition>()
            : Colour == Colour.White
                ?
                [
                    new MoveProposition { Target = Square.At(File.G, Rank.One), SubsequentMove = MoveType.Castle },
                    new MoveProposition { Target = Square.At(File.C, Rank.One), SubsequentMove = MoveType.Castle },
                ]
                :
                [
                    new MoveProposition { Target = Square.At(File.G, Rank.Eight), SubsequentMove = MoveType.Castle },
                    new MoveProposition { Target = Square.At(File.C, Rank.Eight), SubsequentMove = MoveType.Castle },
                ];
        return standardMoves.Concat(castlingMoves);
    }

    public override IEnumerable<MoveProposition> GetIntrinsicCaptures() =>
        GetMoves().Select(s => new MoveProposition { Target = s, SubsequentMove = MoveType.Standard });

    public override IEnumerable<Square> GetPotentialBlocks(Square destination) => GetMoves();

    public Rook? GetCastlingRook(Square destination)
    {
        return KingsideRook;
    }
    
    public override object Clone() => CloneObject<King>();

    public Rook KingsideRook { private get; init; } = default!;
    public Rook QueensideRook { private get; init; } = default!;
    
    private IEnumerable<Square> GetMoves() =>
        Enumerable.Range(Position.File.Dec, Position.File.Inc - Position.File.Dec + 1)
            .SelectMany(i => Enumerable.Range(Position.Rank.Dec, Position.Rank.Inc - Position.Rank.Dec + 1)
                .Select(j => Square.At(File.At(i), Rank.At(j))))
            .Where(s => s != Position);

    public override string ToString() => Colour switch
    {
        Colour.White => "♔",
        Colour.Black => "♚",
        _ => throw new ArgumentOutOfRangeException()
    };
}