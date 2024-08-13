namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Pieces;

public class Query(IPieceGroup pieceGroup) : IQuery
{
    public bool IsInCheck(Colour colour) => pieceGroup.Pieces
        .Where(p => p.Colour != colour)
        .Any(p =>
        {
            var checkTarget = p.GetIntrinsicCaptures()
                .SingleOrDefault(mp => mp.Target == pieceGroup.King(colour).Position);
            return checkTarget is not null && !IsPieceBlockedForCapture(checkTarget.Target, p);
        });

    public bool IsDestinationIntrinsic(Square destination, IPiece pieceToMove)
    {
        var intrinsicMoves = pieceToMove.GetIntrinsicRelocations().Concat(pieceToMove.GetIntrinsicCaptures()).ToArray();
        return intrinsicMoves.Select(mp => mp.Target).Contains(destination);
    }

    public bool WouldRequestResultInCheck(Square proposedDestination, IPiece pieceToMove)
    {
        var ghostPieces = pieceGroup.Pieces
            .Where(p => p.Position != proposedDestination && p.Position != pieceToMove.Position).ToList();
        var ghostPieceToMove = (IPiece)pieceToMove.Clone();
        ghostPieceToMove.Position = proposedDestination;
        ghostPieces.Add(ghostPieceToMove);
        var ghostPieceGroup = new PieceGroup { Pieces = ghostPieces };
        return new Query(ghostPieceGroup).IsInCheck(pieceToMove.Colour);
    }

    public bool IsDestinationOccupied(Square destination)
    {
        return pieceGroup.Pieces.Any(p => p.Position == destination);
    }

    public bool IsPieceBlockedForCapture(Square destination, IPiece pieceToMove)
    {
        return false;
    }

    public bool IsPieceBlockedForRelocation(Square destination, IPiece pieceToMove)
    {
        return false;
    }

    public MoveType GetMoveType(Square destination, IPiece pieceToMove)
    {
        return MoveType.Standard;
    }

    public IPiece? PieceAt(Square location)
    {
        return pieceGroup.PieceAt(location.File, location.Rank);
    }
    
    public IPiece? PieceAt(File file, Rank rank)
    {
        return pieceGroup.PieceAt(file, rank);
    }
}