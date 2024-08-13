namespace Jdev.ChessEngine.Tests.Legislator;

using Board;
using Factory;
using Legislation;

[TestFixture]
public class Holding
{
    private Standard _baseLegislator = default!;
    
    [SetUp]
    public void SetUp()
    {
        _baseLegislator = new StandardLegislatorFactory(new PieceFactory()).Create();
    }

    [Test]
    public void Asdf()
    {
        // var zero = _baseLegislator.Query.PieceGroup;
        // _baseLegislator.EnactMove(new MoveRequest
        // {
        //     PieceToMove = _baseLegislator.Query.PieceAt(File.E, Rank.Two)!,
        //     Destination = Square.At(File.E, Rank.Four)
        // });
        // var one = _baseLegislator.Query.PieceGroup;
        // _baseLegislator.EnactMove(new MoveRequest
        // {
        //     PieceToMove = _baseLegislator.Query.PieceAt(File.D, Rank.Seven)!,
        //     Destination = Square.At(File.D, Rank.Five)
        // });
        // var two = _baseLegislator.Query.PieceGroup;
    }
}