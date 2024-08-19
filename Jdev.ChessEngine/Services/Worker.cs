namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Factory;
using Pieces;

public class Worker(PieceGroup pieceGroup, IPieceFactory pieceFactory) : IWorker
{
    public void KillPiece(IPiece piece)
    {
        pieceGroup.Pieces.Remove(piece);
    }

    public void SpawnPiece<T>(ISquare location, Colour colour) where T : IPiece, new()
    {
        var spawnedPiece = pieceFactory.Create<T>(location, colour);
        pieceGroup.Pieces.Add(spawnedPiece);
    }

    public void RelocatePiece(IPiece piece, ISquare destination)
    {
        piece.Position = destination;
    }

    public void Castle(IKing king, ISquare destination)
    {
        var castlingRook = king.GetCastlingRook(destination);
        castlingRook.Position = castlingRook.CastlingLocation;
        king.Position = destination;
    }
}