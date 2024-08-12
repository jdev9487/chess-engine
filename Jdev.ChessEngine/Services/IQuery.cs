namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Pieces;

public interface IQuery
{
    PieceGroup PieceGroup { get; }
    bool IsInCheck(Colour colour);
    bool IsDestinationIntrinsic(Square destination, BasePiece pieceToMove);
    bool DoesRequestUncheckMover(Square proposedDestination, BasePiece pieceToMove);
    bool DoesRequestPlaceMoverInCheck(Square proposedDestination, BasePiece pieceToMove);
    bool IsDestinationOccupied(Square destination);
    bool IsPieceBlockedForCapture(Square destination, BasePiece pieceToMove);
    bool IsPieceBlockedForRelocation(Square destination, BasePiece pieceToMove);
    MoveType GetMoveType(Square destination, BasePiece pieceToMove);
    BasePiece? PieceAt(Square location);
    BasePiece? PieceAt(File file, Rank rank);
}