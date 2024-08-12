namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Pieces;

public class Query(PieceGroup pieceGroup) : IQuery
{
    public PieceGroup PieceGroup => pieceGroup;

    public bool IsInCheck(Colour colour)
    {
        return false;
    }

    public bool IsDestinationIntrinsic(Square destination, BasePiece pieceToMove)
    {
        var intrinsicMoves = pieceToMove.GetIntrinsicRelocations().Concat(pieceToMove.GetIntrinsicCaptures()).ToArray();
        return intrinsicMoves.Select(mp => mp.Target).Contains(destination);
    }

    public bool DoesRequestUncheckMover(Square proposedDestination, BasePiece pieceToMove)
    {
        return false;
    }

    public bool DoesRequestPlaceMoverInCheck(Square proposedDestination, BasePiece pieceToMove)
    {
        return false;
    }

    public bool IsDestinationOccupied(Square destination)
    {
        return pieceGroup.Pieces.Any(p => p.Position == destination);
    }

    public bool IsPieceBlockedForCapture(Square destination, BasePiece pieceToMove)
    {
        return false;
    }

    public bool IsPieceBlockedForRelocation(Square destination, BasePiece pieceToMove)
    {
        return false;
    }

    public MoveType GetMoveType(Square destination, BasePiece pieceToMove)
    {
        return MoveType.Standard;
    }

    public BasePiece? PieceAt(Square location)
    {
        return pieceGroup.PieceAt(location.File, location.Rank);
    }
    
    public BasePiece? PieceAt(File file, Rank rank)
    {
        return pieceGroup.PieceAt(file, rank);
    }
}