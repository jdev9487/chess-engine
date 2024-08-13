namespace Jdev.ChessEngine.Pieces;

using Board;
using System.Text;

public class PieceGroup
{
    public IList<BasePiece> Pieces { get; init; } = default!;

    public BasePiece? PieceAt(File file, Rank rank) => Pieces.SingleOrDefault(p => p.Position == Square.At(file, rank));
    public override string ToString()
    {
        var stringBoard = new StringBuilder();
        foreach (var rank in Rank.Enumerate.Reverse())
        {
            var values = File.Enumerate.Select(file => PieceAt(file, rank))
                .Select(piece => piece is null ? "-" : piece.ToString()).ToList();

            stringBoard.AppendLine(string.Join(" ", values));
        }

        return stringBoard.ToString();
    }
}