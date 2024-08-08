namespace Jdev.ChessEngine.Factory;

using Enums;
using Models;
using Pieces;
using Services;
using Interfaces;

public class StandardLegislatorFactory(IPieceFactory pieceFactory) : LegislatorFactory
{
    protected override ILegislator Create(PieceGroup pieceGroup) =>
        new Standard(new Query(pieceGroup), new Worker(pieceGroup, pieceFactory));

    protected override PieceGroup CreatePieces()
    {
        var pieces = new List<IPiece>
        {
            pieceFactory.Create(PieceType.Rook, Square.At(File.A, Rank.One), Colour.White),
            pieceFactory.Create(PieceType.Knight, Square.At(File.B, Rank.One), Colour.White),
            pieceFactory.Create(PieceType.Bishop, Square.At(File.C, Rank.One), Colour.White),
            pieceFactory.Create(PieceType.Queen, Square.At(File.D, Rank.One), Colour.White),
            pieceFactory.Create(PieceType.King, Square.At(File.E, Rank.One), Colour.White),
            pieceFactory.Create(PieceType.Bishop, Square.At(File.F, Rank.One), Colour.White),
            pieceFactory.Create(PieceType.Knight, Square.At(File.G, Rank.One), Colour.White),
            pieceFactory.Create(PieceType.Rook, Square.At(File.H, Rank.One), Colour.White),
            
            pieceFactory.Create(PieceType.Pawn, Square.At(File.A, Rank.Two), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.B, Rank.Two), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.C, Rank.Two), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.D, Rank.Two), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.E, Rank.Two), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.F, Rank.Two), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.G, Rank.Two), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.H, Rank.Two), Colour.White),
            
            pieceFactory.Create(PieceType.Pawn, Square.At(File.A, Rank.Seven), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.B, Rank.Seven), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.C, Rank.Seven), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.D, Rank.Seven), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.E, Rank.Seven), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.F, Rank.Seven), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.G, Rank.Seven), Colour.White),
            pieceFactory.Create(PieceType.Pawn, Square.At(File.H, Rank.Seven), Colour.White),
            
            pieceFactory.Create(PieceType.Rook, Square.At(File.A, Rank.Eight), Colour.White),
            pieceFactory.Create(PieceType.Knight, Square.At(File.B, Rank.Eight), Colour.White),
            pieceFactory.Create(PieceType.Bishop, Square.At(File.C, Rank.Eight), Colour.White),
            pieceFactory.Create(PieceType.Queen, Square.At(File.D, Rank.Eight), Colour.White),
            pieceFactory.Create(PieceType.King, Square.At(File.E, Rank.Eight), Colour.White),
            pieceFactory.Create(PieceType.Bishop, Square.At(File.F, Rank.Eight), Colour.White),
            pieceFactory.Create(PieceType.Knight, Square.At(File.G, Rank.Eight), Colour.White),
            pieceFactory.Create(PieceType.Rook, Square.At(File.H, Rank.Eight), Colour.White)
        };
        return new PieceGroup { Pieces = pieces };
    }
}