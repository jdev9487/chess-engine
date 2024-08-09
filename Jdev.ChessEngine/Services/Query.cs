namespace Jdev.ChessEngine.Services;

using Enums;
using Interfaces;
using Models;

public class Query(PieceGroup pieceGroup) : IQuery
{
    public PieceGroup PieceGroup => pieceGroup;

    public bool IsInCheck(Colour colour)
    {
        return false;
    }

    public bool IsDestinationIntrinsic(Square destination, IPiece pieceToMove)
    {
        var intrinsicMoves = pieceToMove.GetIntrinsicRelocations().Concat(pieceToMove.GetIntrinsicCaptures()).ToArray();
        return intrinsicMoves.Select(mp => mp.Target).Contains(destination);
    }

    public bool DoesRequestUncheckMover(Square proposedDestination, IPiece pieceToMove)
    {
        return false;
    }

    public bool DoesRequestPlaceMoverInCheck(Square proposedDestination, IPiece pieceToMove)
    {
        return false;
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