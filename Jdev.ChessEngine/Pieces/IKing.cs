namespace Jdev.ChessEngine.Pieces;

using Board;

public interface IKing : IPiece, IHasMoved
{
    IRook? GetCastlingRook(ISquare destination);
}