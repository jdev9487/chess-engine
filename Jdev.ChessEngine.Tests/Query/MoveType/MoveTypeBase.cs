namespace Jdev.ChessEngine.Tests.Query.MoveType;

using Board;
using Enums;
using Jdev.ChessEngine.Pieces;

[TestFixture]
public class MoveTypeBase : QueryBase
{
    private protected MoveType GetMoveType() => Query.GetMoveType(Destination, PieceToMove);
    private protected ISquare Destination = default!;
    private protected IPiece PieceToMove = default!;
}