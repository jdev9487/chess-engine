namespace Jdev.ChessEngine.Interfaces;

using Enums;
using Models;
using Pieces;

public interface IPieceFactory
{
    IPiece Create(PieceType pieceType, Square location, Colour colour, Square? castlingLocation = null, Rook? queenside = null, Rook? kingside = null);
}