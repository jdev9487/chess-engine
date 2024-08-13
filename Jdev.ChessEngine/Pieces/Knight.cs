namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class Knight : BasePiece
{
    public override IEnumerable<MoveProposition> GetIntrinsicRelocations()
    {
        var steps = new (int fs, int rs)[]
        {
            (1, 2),
            (2, 1),
            (2, -1),
            (1, -2),
            (-1, -2),
            (-2, -1),
            (-2, 1),
            (-1, 2)
        };
        var asdf = steps
            .Select(s => (Position.File + s.fs, Position.Rank + s.rs)).ToList();
        return asdf.Where(x => x.Item1 is not null && x.Item2 is not null)
            .Select(x => new MoveProposition
                { Target = Square.At(x.Item1!, x.Item2!), SubsequentMove = MoveType.Standard });
    }

    public override IEnumerable<MoveProposition> GetIntrinsicCaptures() => GetIntrinsicRelocations();

    public override List<Square> GetPotentialBlocks(Square destination) => [];

    public override string ToString() => Colour switch
    {
        Colour.White => "♘",
        Colour.Black => "♞",
        _ => throw new ArgumentOutOfRangeException()
    };
}