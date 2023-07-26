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

    private const int MaxDepth = 1;

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
            return EvaluateBoard(board);
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

                bestScore = Math.Max(bestScore, score);
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

        score += EvaluatePieceWeight(board);

        return score;
    }

    private int EvaluatePieceWeight(Board board)
    {
        int score = 0;

        foreach (PieceList pieceList in board.GetAllPieceLists())
        {
            foreach (Piece piece in pieceList)
            {
                int pieceScore = 0;

                switch (piece.PieceType)
                {
                    case PieceType.Pawn:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Pawn] : -pieceValues[PieceType.Pawn];
                            break;
                        }
                    case PieceType.Knight:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Knight] : -pieceValues[PieceType.Knight];
                            break;
                        }
                    case PieceType.Bishop:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Bishop] : -pieceValues[PieceType.Bishop];
                            break;
                        }
                    case PieceType.Rook:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Rook] : -pieceValues[PieceType.Rook];
                            break;
                        }
                    case PieceType.Queen:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Queen] : -pieceValues[PieceType.Queen];
                            break;
                        }
                    case PieceType.King:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.King] : -pieceValues[PieceType.King];
                            break;
                        }
                }
                score += pieceScore;
            }
        }
        return score;
    }

    private int EvaluatePiecePosition(Board board)
    {
        int score = 0;

        foreach (PieceList pieceList in board.GetAllPieceLists())
        {
            foreach (Piece piece in pieceList)
            {
                int pieceScore = 0;

                switch (piece.PieceType)
                {
                    case PieceType.Pawn:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Pawn] : -pieceValues[PieceType.Pawn];
                            break;
                        }
                    case PieceType.Knight:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Knight] : -pieceValues[PieceType.Knight];
                            break;
                        }
                    case PieceType.Bishop:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Bishop] : -pieceValues[PieceType.Bishop];
                            break;
                        }
                    case PieceType.Rook:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Rook] : -pieceValues[PieceType.Rook];
                            break;
                        }
                    case PieceType.Queen:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.Queen] : -pieceValues[PieceType.Queen];
                            break;
                        }
                    case PieceType.King:
                        {
                            pieceScore = piece.IsWhite ? pieceValues[PieceType.King] : -pieceValues[PieceType.King];
                            break;
                        }
                }
                score += pieceScore;
            }
        }
        return score;
    }
}