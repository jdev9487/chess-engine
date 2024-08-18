namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class King : BasePiece, IKing
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

    public override IEnumerable<ISquare> GetPotentialRelocationBlocks(ISquare destination)
    {
        if (!Position.IsTouching(destination)) return [];
        return Position.GetDiagonalsInBetween(destination)
            .Concat(Position.GetStraightsInBetween(destination))
            .Where(s => s != Position);
    }

    public override IEnumerable<ISquare> GetPotentialCaptureBlocks(ISquare destination) =>
        GetPotentialRelocationBlocks(destination);

    public IRook? GetCastlingRook(ISquare destination) =>
        Colour switch
        {
            Colour.White => destination switch
            {
                not null when destination == Square.At(File.G, Rank.One) => KingsideRook,
                not null when destination == Square.At(File.C, Rank.One) => QueensideRook,
                _ => null
            },
            Colour.Black => destination switch
            {
                not null when destination == Square.At(File.G, Rank.Eight) => KingsideRook,
                not null when destination == Square.At(File.C, Rank.Eight) => QueensideRook,
                _ => null
            },
            _ => throw new ArgumentOutOfRangeException()
        };

    public override object Clone() => CloneObject<King>();

    public Rook KingsideRook { private get; init; } = default!;
    public Rook QueensideRook { private get; init; } = default!;
    public bool HasMoved { get; set; } = false;
    
    private IEnumerable<ISquare> GetMoves() =>
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