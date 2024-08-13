namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Pieces;

public interface IWorker
{
    void KillPiece(IPiece piece);
    void SpawnPiece<T>(Square location, Colour colour) where T : IPiece, new();
    void RelocatePiece(IPiece piece, Square destination);
    void Castle(King king, Square destination);
}