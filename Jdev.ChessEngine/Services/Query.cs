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
                .SingleOrDefault(s => s == pieceGroup.King(colour).Position);
            return checkTarget is not null && !IsPieceBlockedForCapture(checkTarget, p);
        });

    public bool IsDestinationIntrinsic(ISquare destination, IPiece pieceToMove)
    {
        var intrinsicMoves = pieceToMove.GetIntrinsicRelocations().Concat(pieceToMove.GetIntrinsicCaptures()).ToArray();
        return intrinsicMoves.Contains(destination);
    }

    public bool WouldRequestResultInCheck(ISquare proposedDestination, IPiece pieceToMove)
    {
        var ghostPieces = pieceGroup.Pieces
            .Where(p => p.Position != proposedDestination && p.Position != pieceToMove.Position).ToList();
        var ghostPieceToMove = (IPiece)pieceToMove.Clone();
        ghostPieceToMove.Position = proposedDestination;
        ghostPieces.Add(ghostPieceToMove);
        var ghostPieceGroup = new PieceGroup { Pieces = ghostPieces };
        return new Query(ghostPieceGroup).IsInCheck(pieceToMove.Colour);
    }

    public bool IsDestinationOccupied(ISquare destination) => pieceGroup.PieceAt(destination) is not null;

    public bool IsPieceBlockedForCapture(ISquare destination, IPiece pieceToMove)
    {
        var potentialBlocks = pieceToMove
            .GetPotentialCaptureBlocks(destination)
            .Where(s => s != destination).ToArray();
        var destinationPiece = PieceAt(destination);
        return potentialBlocks.Any(s => PieceAt(s) is not null) ||
               (destinationPiece is not null && destinationPiece.Colour == pieceToMove.Colour);
    }

    public bool IsPieceBlockedForRelocation(ISquare destination, IPiece pieceToMove)
    {
        if (pieceToMove is IPawn && GetMoveType(destination, pieceToMove) == MoveType.Standard)
            return pieceToMove.Position.File != destination.File;
        return pieceToMove.GetPotentialRelocationBlocks(destination)
            .Any(s => PieceAt(s) is not null);
    }

    public bool CanKingCastle(IKing castlingKing, ISquare destination)
    {
        if (castlingKing.HasMoved) return false;
        var castlingRook = castlingKing.GetCastlingRook(destination);
        if (castlingRook is null || castlingRook.HasMoved) return false;
        var squaresInBetweenCastlingRook = castlingKing.Position.GetStraightsInBetween(castlingRook.Position)
            .Where(s => s != castlingRook.Position)
            .Where(s => s != castlingKing.Position);
        if (squaresInBetweenCastlingRook.Any(s => PieceAt(s) is not null)) return false;
        var squaresInBetweenCastlingLocation = castlingKing.Position.GetStraightsInBetween(destination)
            .Where(s => s != castlingKing.Position);
        return !squaresInBetweenCastlingLocation.Any(square => WouldRequestResultInCheck(square, castlingKing));
    }

    public MoveType GetMoveType(ISquare destination, IPiece pieceToMove)
    {
        switch (pieceToMove)
        {
            case Pawn when pieceToMove.Colour == Colour.White && destination.Rank == Rank.Eight:
            case Pawn when pieceToMove.Colour == Colour.Black && destination.Rank == Rank.One:
                return MoveType.Promotion;
            case King { Colour: Colour.White, HasMoved: false }
                when destination == Square.At(File.G, Rank.One) || destination == Square.At(File.C, Rank.One):
            case King { Colour: Colour.Black, HasMoved: false }
                when destination == Square.At(File.G, Rank.Eight) || destination == Square.At(File.C, Rank.Eight):
                return MoveType.Castle;
            case Pawn when AttemptingEnPassant(pieceToMove, destination):
                return MoveType.EnPassant;
            default:
                return MoveType.Standard;
        }
    }

    public IPiece? PieceAt(ISquare location) => pieceGroup.PieceAt(location.File, location.Rank);

    public IPieceGroup PieceGroup => pieceGroup;
    
    public IPawn? GetPawnToBeCapturedByEnPassant(IPiece pieceToMove, ISquare requestDestination)
    {
        var rank = pieceToMove.Colour == Colour.White
            ? requestDestination.Rank - 1
            : requestDestination.Rank + 1;
        if (rank is null) return null;
        return (IPawn?)PieceAt(requestDestination.File, rank);
    }

    private IPiece? PieceAt(File file, Rank rank) => pieceGroup.PieceAt(file, rank);

    private bool AttemptingEnPassant(IPiece pieceToMove, ISquare destination)
    {
        var fileToRight = pieceToMove.Position.File + 1;
        var fileToLeft = pieceToMove.Position.File - 1;
        var captureOriginRank = pieceToMove.Colour == Colour.White ? Rank.Five : Rank.Four;
        var captureDestinationRank = pieceToMove.Colour == Colour.White ? Rank.Six : Rank.Three;
        var captiveRank = pieceToMove.Colour == Colour.White ? destination.Rank - 1 : destination.Rank + 1;
            return pieceToMove.Position.Rank == captureOriginRank &&
               destination.Rank == captureDestinationRank &&
               (destination.File == fileToRight || destination.File == fileToLeft) &&
               captiveRank is not null &&
               PieceAt(destination.File, captiveRank) is not null &&
               PieceAt(destination.File, captiveRank) is IPawn;
    }
}