namespace Jdev.ChessEngine.Pieces;

public interface IPawn : IPiece
{
    bool HasMoved { get; set; }
}