namespace Jdev.ChessEngine.Services;

using Enums;
using Interfaces;
using Models;
using Pieces;

public class Worker(PieceGroup pieceGroup, IPieceFactory pieceFactory) : IWorker
{
    public void KillPiece(IPiece piece)
    {
        pieceGroup.Pieces.Remove(piece);
    }

    public void SpawnPiece(PieceType pieceType, Square location, Colour colour)
    {
        var spawnedPiece = pieceFactory.Create(pieceType, location, colour);
        pieceGroup.Pieces.Add(spawnedPiece);
    }

    public void RelocatePiece(IPiece piece, Square destination)
    {
        piece.Position = destination;
    }

    public void Castle(King king, Square destination)
    {
        var castlingRook = king.GetCastlingRook(destination);
        castlingRook.Position = castlingRook.CastlingLocation;
        king.Position = destination;
    }
}