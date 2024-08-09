namespace Jdev.ChessEngine.Tests.StandardLegislator;

using Factory;
using Interfaces;

public class Base
{
    private protected ILegislator Legislator = default!;
    
    [SetUp]
    public void SetUp()
    {
        var legFac = new StandardLegislatorFactory(new PieceFactory());
        var legislation = legFac.Create();
        
        Legislator = legislation.Legislator;
    }
}