using ChessChallenge.API;
using System;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();

        //Decide on a set of "good" sets.

        //Evaluate the board.

        //Choose the best one.

        return moves[0];
    }
}