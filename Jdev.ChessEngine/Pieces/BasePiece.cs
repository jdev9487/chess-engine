namespace Jdev.ChessEngine.Pieces;

using Enums;
using Models;

public abstract class BasePiece
{
    public abstract IEnumerable<MoveProposition> GetIntrinsicRelocations();
    public abstract IEnumerable<MoveProposition> GetIntrinsicCaptures();
    public abstract List<Square> GetPotentialBlocks(Square destination);
    
    private Square _position = default!;
    public Colour Colour { get; init; }

    public Square Position
    {
        get => _position;
        set
        {
            FileCoord = new Coordinate((int)value.File);
            RankCoord = new Coordinate((int)value.Rank);
            _position = value;
        }
    }

    public bool IsAlive { get; set; } = true;
    public bool HasMoved { get; set; } = false;

    internal Coordinate FileCoord { get; private set; }
    internal Coordinate RankCoord { get; private set; }
}