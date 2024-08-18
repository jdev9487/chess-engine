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

    public bool IsDestinationIntrinsic(ISquare destination, IPiece pieceToMove)
    {
        var intrinsicMoves = pieceToMove.GetIntrinsicRelocations().Concat(pieceToMove.GetIntrinsicCaptures()).ToArray();
        return intrinsicMoves.Select(mp => mp.Target).Contains(destination);
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

    public bool IsDestinationOccupied(ISquare destination)
    {
        return pieceGroup.PieceAt(destination) is not null;
    }

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
            default:
                return MoveType.Standard;
        }
    }

    public IPiece? PieceAt(ISquare location)
    {
        return pieceGroup.PieceAt(location.File, location.Rank);
    }
    
    public IPiece? PieceAt(File file, Rank rank)
    {
        return pieceGroup.PieceAt(file, rank);
    }
}