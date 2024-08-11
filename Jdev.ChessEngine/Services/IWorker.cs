namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Models;
using Pieces;

public interface IWorker
{
    void KillPiece(BasePiece piece);
    void SpawnPiece<T>(Square location, Colour colour) where T : BasePiece, new();
    void RelocatePiece(BasePiece piece, Square destination);
    void Castle(King king, Square destination);
}