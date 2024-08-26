namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Factory;
using Pieces;

public class Worker(IPieceGroup pieceGroup, IPieceFactory pieceFactory) : IWorker
{
    public void KillPiece(IPiece piece) => pieceGroup.Pieces.Remove(piece);

    public void SpawnPiece<T>(ISquare location, Colour colour) where T : IPiece, new()
    {
        var spawnedPiece = pieceFactory.Create<T>(location, colour);
        pieceGroup.Pieces.Add(spawnedPiece);
    }

    public void RelocatePiece(IPiece piece, ISquare destination)
    {
        if (piece is IPawn pawn && Rank.Distance(pawn.Position.Rank, destination.Rank) == 2)
            pawn.OpenToEnPassant = true;
        piece.Position = destination;
        if (piece is IHasMoved hasMovedAblePiece) UpdateHasMoved(hasMovedAblePiece);
    }

    public void Castle(IKing king, ISquare destination)
    {
        var castlingRook = king.GetCastlingRook(destination)!;
        castlingRook.Position = castlingRook.CastlingLocation;
        king.Position = destination;
        UpdateHasMoved(castlingRook);
        UpdateHasMoved(king);
    }
    
    public void UpdateEnPassantStatus(Colour colour)
    {
        var pawns = pieceGroup.Pieces
            .Where(x => x.Colour == colour)
            .Where(x => x is IPawn).Cast<IPawn>();
        foreach (var pawn in pawns) pawn.OpenToEnPassant = false;
    }

    private static void UpdateHasMoved(IHasMoved piece) => piece.HasMoved = true;
}