namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Pieces;

public interface IWorker
{
    void KillPiece(IPiece piece);
    void SpawnPiece<T>(ISquare location, Colour colour) where T : IPiece, new();
    void RelocatePiece(IPiece piece, ISquare destination);
    void Castle(IKing king, ISquare destination);
}