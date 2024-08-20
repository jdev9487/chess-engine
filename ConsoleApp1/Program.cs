using Jdev.ChessEngine.Board;
using Jdev.ChessEngine.Factory;
using Jdev.ChessEngine.Legislation;
using Jdev.ChessEngine.Pieces;
using File = Jdev.ChessEngine.Board.File;

var slf = new StandardLegislatorFactory(new PieceFactory());
var standard = slf.Create();

var pieces = standard.PieceGroup;
Console.BackgroundColor = ConsoleColor.DarkYellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine(pieces);

while (true)
{
    var move = Console.ReadLine();
    var response = standard.EnactMove(new MoveRequest
    {
        Origin = Square.At(GetFile(move[0]), GetRank(move[1])),
        Destination = Square.At(GetFile(move[2]), GetRank(move[3]))
    });
    if (response.PromotionNecessary)
    {
        var promRequest = response.CreateSubsequentRequest();
        standard.Promote<Queen>(promRequest);
    }
    Console.Clear();
    Console.WriteLine(pieces);
}

File GetFile(char file)
{
    return file.ToString().ToLower() switch
    {
        "a" => File.A,
        "b" => File.B,
        "c" => File.C,
        "d" => File.D,
        "e" => File.E,
        "f" => File.F,
        "g" => File.G,
        "h" => File.H,
    };
}
Rank GetRank(char rank)
{
    return rank.ToString() switch
    {
        "1" => Rank.One,
        "2" => Rank.Two,
        "3" => Rank.Three,
        "4" => Rank.Four,
        "5" => Rank.Five,
        "6" => Rank.Six,
        "7" => Rank.Seven,
        "8" => Rank.Eight
    };
}

standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.E, Rank.Two),
    Destination = Square.At(File.E, Rank.Four)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.C, Rank.Seven),
    Destination = Square.At(File.C, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.F, Rank.One),
    Destination = Square.At(File.C, Rank.Four)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.D, Rank.Seven),
    Destination = Square.At(File.D, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.E, Rank.Four),
    Destination = Square.At(File.D, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.D, Rank.Eight),
    Destination = Square.At(File.D, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.C, Rank.Four),
    Destination = Square.At(File.B, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.C, Rank.Eight),
    Destination = Square.At(File.D, Rank.Seven)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.G, Rank.One),
    Destination = Square.At(File.F, Rank.Three)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.B, Rank.Eight),
    Destination = Square.At(File.C, Rank.Six)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.E, Rank.One),
    Destination = Square.At(File.G, Rank.One)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.E, Rank.Eight),
    Destination = Square.At(File.C, Rank.Eight)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.B, Rank.Five),
    Destination = Square.At(File.C, Rank.Six)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.B, Rank.Seven),
    Destination = Square.At(File.C, Rank.Six)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.B, Rank.Two),
    Destination = Square.At(File.B, Rank.Four)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.C, Rank.Five),
    Destination = Square.At(File.C, Rank.Four)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.B, Rank.Four),
    Destination = Square.At(File.B, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.C, Rank.Six),
    Destination = Square.At(File.C, Rank.Five)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.B, Rank.Five),
    Destination = Square.At(File.B, Rank.Six)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.D, Rank.Seven),
    Destination = Square.At(File.H, Rank.Three)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.B, Rank.Six),
    Destination = Square.At(File.B, Rank.Seven)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.C, Rank.Eight),
    Destination = Square.At(File.C, Rank.Seven)
});
var res = standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.B, Rank.Seven),
    Destination = Square.At(File.B, Rank.Eight)
});
var promotionRequest = res.CreateSubsequentRequest();
if (promotionRequest is not null) standard.Promote<Queen>(promotionRequest);
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.D, Rank.Eight),
    Destination = Square.At(File.B, Rank.Eight)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.D, Rank.Two),
    Destination = Square.At(File.D, Rank.Four)
});
standard.EnactMove(new MoveRequest
{
    Origin = Square.At(File.C, Rank.Four),
    Destination = Square.At(File.D, Rank.Three)
});

Console.WriteLine();
