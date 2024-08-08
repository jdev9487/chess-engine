namespace Jdev.ChessEngine.Interfaces;

using Enums;
using Models;
using Pieces;

public interface IWorker
{
    void KillPiece(IPiece piece);
    void SpawnPiece(PieceType pieceType, Square location, Colour colour);
    void RelocatePiece(IPiece piece, Square destination);
    void Castle(King king, Square destination);
}