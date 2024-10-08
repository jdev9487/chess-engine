namespace Jdev.ChessEngine.Services;

using Board;
using Enums;
using Pieces;

public interface IQuery
{
    bool IsInCheck(Colour colour);
    bool IsDestinationIntrinsic(ISquare destination, IPiece pieceToMove);
    bool WouldRequestResultInCheck(ISquare proposedDestination, IPiece pieceToMove);
    bool IsDestinationOccupied(ISquare destination);
    bool IsPieceBlockedForCapture(ISquare destination, IPiece pieceToMove);
    bool IsPieceBlockedForRelocation(ISquare destination, IPiece pieceToMove);
    bool CanKingCastle(IKing castlingKing, ISquare destination);
    MoveType GetMoveType(ISquare destination, IPiece pieceToMove);
    IPiece? PieceAt(ISquare location);
    IPieceGroup PieceGroup { get; }
    IPawn? GetPawnToBeCapturedByEnPassant(IPiece pieceToMove, ISquare requestDestination);
}