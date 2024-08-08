namespace Jdev.ChessEngine.Interfaces;

using Enums;
using Models;
using Pieces;

public interface IWorker
{
    void KillPiece(IPiece piece);
    void SpawnPiece(PromotionType promotionType, Square location);
    void RelocatePiece(IPiece piece, Square destination);
    void Castle(King king, Square destination);
}