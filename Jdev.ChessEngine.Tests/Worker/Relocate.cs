namespace Jdev.ChessEngine.Tests.Worker;

using Board;
using ChessEngine.Pieces;

[TestFixture]
public class Relocate : WorkerBase
{
    [Test]
    public void ShouldUpdatePositionOfPiece()
    {
        var origin = Square.At(File.G, Rank.Five);
        var destination = Square.At(File.F, Rank.Five);
        var piece = new Bishop { Position = origin };
        Worker.RelocatePiece(piece, destination);
        Assert.That(piece.Position, Is.SameAs(destination));
    }
    
    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void ShouldUpdateHasMovedForKing(bool hasMoved)
    {
        var origin = Square.At(File.G, Rank.Five);
        var destination = Square.At(File.F, Rank.Five);
        var piece = new King { Position = origin, HasMoved = hasMoved };
        Worker.RelocatePiece(piece, destination);
        Assert.That(piece.HasMoved, Is.True);
    }
    
    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public void ShouldUpdateHasMovedForRook(bool hasMoved)
    {
        var origin = Square.At(File.G, Rank.Five);
        var destination = Square.At(File.F, Rank.Five);
        var piece = new Rook { Position = origin, HasMoved = hasMoved };
        Worker.RelocatePiece(piece, destination);
        Assert.That(piece.HasMoved, Is.True);
    }
}