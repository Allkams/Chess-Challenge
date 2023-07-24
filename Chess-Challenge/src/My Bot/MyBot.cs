using ChessChallenge.API;
using System;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();

        Random rand = new Random();

        int moveNR =  rand.Next(moves.Length);

        return moves[moveNR];
    }
}