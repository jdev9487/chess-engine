namespace Jdev.ChessEngine.Tests.Legislator;

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
        var x = _baseLegislator.Query.PieceGroup;
        var y = 2;
    }
}