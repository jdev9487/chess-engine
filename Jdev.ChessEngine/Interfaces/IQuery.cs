namespace Jdev.ChessEngine.Interfaces;

using Enums;
using Models;

public interface IQuery
{
    PieceGroup PieceGroup { get; }
    bool IsInCheck(Colour colour);
    bool IsDestinationIntrinsic(Square destination, IPiece pieceToMove);
    bool DoesRequestUncheckMover(Square proposedDestination, IPiece pieceToMove);
    bool DoesRequestPlaceMoverInCheck(Square proposedDestination, IPiece pieceToMove);
    bool IsDestinationOccupied(Square destination);
    bool IsPieceBlockedForCapture(Square destination, IPiece pieceToMove);
    bool IsPieceBlockedForRelocation(Square destination, IPiece pieceToMove);
    MoveType GetMoveType(Square destination, IPiece pieceToMove);
    IPiece? PieceAt(Square location);
    IPiece? PieceAt(File file, Rank rank);
}