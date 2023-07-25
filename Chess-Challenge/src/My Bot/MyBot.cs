using ChessChallenge.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class MyBot : IChessBot
{
    private int[,] posMap = new int[8, 8];
    private Dictionary<PieceType, int> pieceValues = new Dictionary<PieceType, int>
    {
        { PieceType.None, 0 },
        { PieceType.Pawn, 10 },
        { PieceType.Knight, 30 },
        { PieceType.Bishop, 30 },
        { PieceType.Rook, 50 },
        { PieceType.Queen, 90 },
        { PieceType.King, 900 },
    };

    private const int MaxDepth = 2;

    public Move Think(Board board, Timer timer)
    {
        int bestScore = int.MinValue;
        Move bestMove = Move.NullMove;

        Move[] moves = board.GetLegalMoves();

        foreach (Move move in moves)
        {
            board.MakeMove(move);

            int score = Minmax(board, MaxDepth, false);

            board.UndoMove(move);

            if (score > bestScore)
            {
                bestScore = score;
                bestMove = move;
            }
        }

        return bestMove;
    }

    private int Minmax(Board board, int depth, bool isMaximizing)
    {
        if(depth == 0)
        {
            EvaluateBoard(board);
        }

        int bestScore;

        if(isMaximizing)
        {
            bestScore = int.MinValue;
            Move[] moves = board.GetLegalMoves();

            foreach (Move move in moves)
            {
                board.MakeMove(move);

                int score = Minmax(board, depth - 1, false);

                board.UndoMove(move);

                bestScore = Math.Min(bestScore, score);
            }
        }
        else
        {
            bestScore = int.MaxValue;
            Move[] moves = board.GetLegalMoves();
            foreach (Move move in moves)
            {
                board.MakeMove(move);

                int score = Minmax(board, depth - 1, true);

                board.UndoMove(move);

                bestScore = Math.Min(bestScore, score);
            }
        }
        return bestScore;
    }

    private int EvaluateBoard(Board board)
    {
        int score = 0;

        // Evaluate material balance

        //somehow.


        return new Random().Next(-9000, 9000);
    }
}