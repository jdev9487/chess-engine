namespace Jdev.ChessEngine.Interfaces;

using Enums;
using Models;

public interface IPieceFactory
{
    IPiece Create(PieceType pieceType, Square location, Colour colour);
}