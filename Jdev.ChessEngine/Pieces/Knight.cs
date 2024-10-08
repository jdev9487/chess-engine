namespace Jdev.ChessEngine.Pieces;

using Board;
using Enums;

public class Knight : BasePiece
{
    public override IEnumerable<ISquare> GetIntrinsicRelocations()
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
            .Select(x => Square.At(x.Item1!, x.Item2!));
    }
    public override IEnumerable<ISquare> GetIntrinsicCaptures() => GetIntrinsicRelocations();
    public override IEnumerable<ISquare> GetPotentialRelocationBlocks(ISquare destination) =>
        GetIntrinsicRelocations().Contains(destination) ? [destination] : [];
    public override IEnumerable<ISquare> GetPotentialCaptureBlocks(ISquare destination) =>
        GetPotentialRelocationBlocks(destination);
    
    public override object Clone() => CloneObject<Knight>();

    public override string ToString() => Colour switch
    {
        Colour.White => "♘",
        Colour.Black => "♞",
        _ => throw new ArgumentOutOfRangeException()
    };
}