namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Pieces;

public interface IQuery
{
    bool IsInCheck(Colour colour);
    bool IsDestinationIntrinsic(Square destination, IPiece pieceToMove);
    bool WouldRequestResultInCheck(Square proposedDestination, IPiece pieceToMove);
    bool IsDestinationOccupied(Square destination);
    bool IsPieceBlockedForCapture(Square destination, IPiece pieceToMove);
    bool IsPieceBlockedForRelocation(Square destination, IPiece pieceToMove);
    MoveType GetMoveType(Square destination, IPiece pieceToMove);
    IPiece? PieceAt(Square location);
    IPiece? PieceAt(File file, Rank rank);
}