namespace Jdev.ChessEngine.Factory;

using Board;
using ChessEngine.Legislation;
using Enums;
using Services;
using Pieces;

public class StandardLegislatorFactory(IPieceFactory pieceFactory) : LegislatorFactory
{
    protected override ILegislator Create(PieceGroup pieceGroup) =>
        new Standard(new Query(pieceGroup), new Worker(pieceGroup, pieceFactory));

    protected override PieceGroup CreatePieces()
    {
        var whiteQueensideRook = pieceFactory.CreateRook(Square.At(File.A, Rank.One), Colour.White, Square.At(File.D, Rank.One));
        var whiteKingsideRook = pieceFactory.CreateRook(Square.At(File.H, Rank.One), Colour.White, Square.At(File.F, Rank.One));
        var whiteKing = pieceFactory.CreateKing(Square.At(File.E, Rank.One), Colour.White, kingside: whiteKingsideRook, queenside: whiteQueensideRook);
        
        var blackQueensideRook = pieceFactory.CreateRook(Square.At(File.A, Rank.Eight), Colour.Black, Square.At(File.D, Rank.Eight));
        var blackKingsideRook = pieceFactory.CreateRook(Square.At(File.H, Rank.Eight), Colour.Black, Square.At(File.F, Rank.Eight));
        var blackKing = pieceFactory.CreateKing(Square.At(File.E, Rank.Eight), Colour.Black, kingside: blackKingsideRook, queenside: blackQueensideRook);
        
        var pieces = new List<BasePiece>
        {
            whiteQueensideRook,
            pieceFactory.Create<Knight>(Square.At(File.B, Rank.One), Colour.White),
            pieceFactory.Create<Bishop>(Square.At(File.C, Rank.One), Colour.White),
            pieceFactory.Create<Queen>(Square.At(File.D, Rank.One), Colour.White),
            whiteKing,
            pieceFactory.Create<Bishop>(Square.At(File.F, Rank.One), Colour.White),
            pieceFactory.Create<Knight>(Square.At(File.G, Rank.One), Colour.White),
            whiteKingsideRook,
            
            pieceFactory.Create<Pawn>(Square.At(File.A, Rank.Two), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.B, Rank.Two), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.C, Rank.Two), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.D, Rank.Two), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.E, Rank.Two), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.F, Rank.Two), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.G, Rank.Two), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.H, Rank.Two), Colour.White),
            
            pieceFactory.Create<Pawn>(Square.At(File.A, Rank.Seven), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.B, Rank.Seven), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.C, Rank.Seven), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.D, Rank.Seven), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.E, Rank.Seven), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.F, Rank.Seven), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.G, Rank.Seven), Colour.White),
            pieceFactory.Create<Pawn>(Square.At(File.H, Rank.Seven), Colour.White),
            
            blackQueensideRook,
            pieceFactory.Create<Knight>(Square.At(File.B, Rank.Eight), Colour.White),
            pieceFactory.Create<Bishop>(Square.At(File.C, Rank.Eight), Colour.White),
            pieceFactory.Create<Queen>(Square.At(File.D, Rank.Eight), Colour.White),
            blackKing,
            pieceFactory.Create<Bishop>(Square.At(File.F, Rank.Eight), Colour.White),
            pieceFactory.Create<Knight>(Square.At(File.G, Rank.Eight), Colour.White),
            blackKingsideRook
        };
        return new PieceGroup { Pieces = pieces };
    }
}