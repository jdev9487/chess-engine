namespace Jdev.ChessEngine.Tests.Query.MoveType;

using Enums;
using Models;

[TestFixture]
public class EnPassant : MoveTypeBase
{
    // [Test]
    // [TestCaseSource(nameof(Yes))]
    // public void PawnShouldEnPassant(EnPassantTestModel model)
    // {
    //     Arrange(model);
    //     Assert.That(GetMoveType(), Is.EqualTo(MoveType.EnPassant));
    // }
    //
    // [Test]
    // [TestCaseSource(nameof(NoDueToNotOpen))]
    // public void PawnShouldNotEnPassantDueToNotOpenToEnPassant(EnPassantTestModel model)
    // {
    //     Arrange(model);
    //     Assert.That(GetMoveType(), Is.Not.EqualTo(MoveType.EnPassant));
    // }
    //
    // [Test]
    // [TestCaseSource(nameof(NoPieceToTake))]
    // public void PawnShouldNotEnPassantDueToNoPieceToTake(EnPassantTestModel model)
    // {
    //     Arrange(model);
    //     Assert.That(GetMoveType(), Is.Not.EqualTo(MoveType.EnPassant));
    // }
    //
    // [Test]
    // [TestCaseSource(nameof(NoPawnToTake))]
    // public void PawnShouldNotEnPassantDueToNoPawnToTake(EnPassantTestModel model)
    // {
    //     Arrange(model);
    //     Assert.That(GetMoveType(), Is.Not.EqualTo(MoveType.EnPassant));
    // }
    //
    // private void Arrange(EnPassantTestModel model)
    // {
    //     PieceToMove = model.PawnToCapture;
    //     Destination = model.Destination;
    //     if (model.PieceToBeCaptured is null) return;
    //     PieceGroupMock
    //         .Setup(x => x.PieceAt(model.PieceToBeCaptured.Position.File, model.PieceToBeCaptured.Position.Rank))
    //         .Returns(model.PieceToBeCaptured);
    // }
    //
    // private static readonly object[] Yes =
    // [
    //     Cases.EnPassant.Yes.WhiteCapturesToTheRight,
    //     Cases.EnPassant.Yes.WhiteCapturesToTheLeft,
    //     Cases.EnPassant.Yes.BlackCapturesToTheRight,
    //     Cases.EnPassant.Yes.BlackCapturesToTheLeft
    // ];
    //
    // private static readonly object[] NoDueToNotOpen =
    // [
    //     Cases.EnPassant.NoDueToNotOpen.WhiteCapturesToTheRight,
    //     Cases.EnPassant.NoDueToNotOpen.WhiteCapturesToTheLeft,
    //     Cases.EnPassant.NoDueToNotOpen.BlackCapturesToTheRight,
    //     Cases.EnPassant.NoDueToNotOpen.BlackCapturesToTheLeft
    // ];
    //
    // private static readonly object[] NoPieceToTake =
    // [
    //     Cases.EnPassant.NoDueToNoPieceToTake.WhiteAttempts,
    //     Cases.EnPassant.NoDueToNoPieceToTake.BlackAttempts
    // ];
    //
    // private static readonly object[] NoPawnToTake =
    // [
    //     Cases.EnPassant.NoDueToNoPawnToTake.WhiteAttempts,
    //     Cases.EnPassant.NoDueToNoPawnToTake.BlackAttempts
    // ];
}