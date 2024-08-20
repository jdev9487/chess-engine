namespace Jdev.ChessEngine.Pieces;

public interface IPawn : IPiece
{
    bool OpenToEnPassant { get; set; }
}