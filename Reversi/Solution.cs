using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Reversi
{
    public class BoardPosition
    {
        //this is bascially just a vector2 with added score
        public int posX { get; private set; }
        public int posY { get; private set; }
        public int moveScore { get; private set; }

        //board position with score
        public BoardPosition(int x, int y, int score)
        {
            posX = x;
            posY = y;
            moveScore = score;
        }

        //board position without score
        public BoardPosition(int x, int y)
        {
            posX = x;
            posY = y;
            moveScore = 0;
        }

        //copy constructor
        public BoardPosition(BoardPosition original)
        {
            posX = original.posX;
            posY = original.posY;
            moveScore = original.moveScore;
        }

        public void UpdatePosition(int x, int y)
        {
            posX = x;
            posY = y;
        }
    }

    public class Solution
    {
        public static string PlaceToken(string board)
        {
            //generate new board from text
            Board playingField = new Board();
            playingField.ReadBoardFromText(board);

            //list containing positions with highest score
            List<BoardPosition> highestScorePlays = new List<BoardPosition>();

            //iterate over every field in the board
            for (int yPos = 0; yPos < playingField.mBoard.GetLength(1); yPos++)
            {
                for (int xPos = 0; xPos < playingField.mBoard.GetLength(0); xPos++)
                {

                    //Console.WriteLine("checking field " + xPos + "," + yPos);

                    //if the field is not empty, skip to the next field
                    if (playingField.mBoard[xPos, yPos] != EFieldState.empty)
                        continue;

                    //Console.WriteLine("field " + xPos + "," + yPos + " is empty, continuing with move score calculation");

                    //calculate the points achieved by playing a token here
                    int moveScore = CalculateMoveScore(new BoardPosition(xPos, yPos), playingField).moveScore;

                    //Console.WriteLine("score for move calculated as " + moveScore);

                    //if this is the first recorded play, add it to the list and skip to the next field
                    if (highestScorePlays.Count == 0)
                    {
                        highestScorePlays.Add(new BoardPosition(xPos, yPos, moveScore));
                        continue;
                    }

                    //check if new position should be added to list, replace current list, or be ignored
                    if (moveScore < highestScorePlays[0].moveScore)
                    {
                        //ignore and move to next field
                        continue;
                    }
                    if (moveScore == highestScorePlays[0].moveScore)
                    {
                        //add move to highestScorePlays
                        highestScorePlays.Add(new BoardPosition(xPos, yPos, moveScore));
                        continue;
                    }
                    if (moveScore > highestScorePlays[0].moveScore)
                    {
                        //replace highestScorePlays with new list containing new highscore
                        highestScorePlays = new List<BoardPosition> { new BoardPosition(xPos, yPos, moveScore) };
                        continue;
                    }
                }
            }

            //once finished, turn list entries into string board positions
            List<String> boardPositionStrings = new List<String>();
            foreach (BoardPosition current in highestScorePlays)
                boardPositionStrings.Add(Board.GetStringFromBoardPosition(current));
            //merge string poard positions into output text and return it
            return string.Join(", ", boardPositionStrings);
        }

        public static BoardPosition CalculateMoveScore(BoardPosition startPos, Board referenceBoard)
        {
            //attempts possible moves, and returns it with the score that move will bring the player
            int totalScore = 0;
            BoardPosition reachedTarget = new BoardPosition(startPos.posX, startPos.posY, 0);
            BoardPosition highestScoreTarget = new BoardPosition(startPos.posX, startPos.posY, 0);
            //for x = -1 | 0 | +1
            for (int x = -1; x < 2; x++)
            {
                //for y = -1 | 0 | +1
                for (int y = -1; y < 2; y++)
                {
                    if (!(x == 0 && y == 0))
                    {
                        reachedTarget = CalculateScoreInDirection(startPos, new BoardPosition(x, y), referenceBoard);
                        if (reachedTarget.moveScore > highestScoreTarget.moveScore)
                            highestScoreTarget = new BoardPosition(reachedTarget);
                        totalScore += reachedTarget.moveScore;
                    }
                }
            }
            //update score for chain reactions
            //totalScore += CalculateChainReactionScore(referenceBoard, startPos);
            return new BoardPosition(highestScoreTarget.posX, highestScoreTarget.posY, totalScore);
        }

        public static BoardPosition CalculateScoreInDirection(BoardPosition startPos, BoardPosition direction, Board referenceBoard)
        {
            BoardPosition currentField = new BoardPosition(startPos);
            BoardPosition targetField;

            while (true)
            {
                //first, get target from next step in direction
                targetField = new BoardPosition(currentField.posX + direction.posX, currentField.posY + direction.posY);

                //if next step is ooutside of board bounds, cancel and return no score
                bool inBoundsX = targetField.posX < referenceBoard.mBoard.GetLength(0) && targetField.posX >= 0;
                bool inBoundsY = targetField.posY < referenceBoard.mBoard.GetLength(1) && targetField.posY >= 0;
                if (!inBoundsX || !inBoundsY)
                    return new BoardPosition(startPos.posX, startPos.posY, 0);

                //switch case on target field state
                switch (referenceBoard.mBoard[targetField.posX, targetField.posY])
                {
                    //case enemy: update current and continue from there
                    case (EFieldState.player2):
                        currentField = targetField;
                        continue;

                    //case friendly: stop and calculate score between start and current
                    case (EFieldState.player1):
                        //get amount of fields between startpos and currentpos
                        //to do this, take the target pos, subtract start pos, take the absolute of that value, then subtract 1
                        int differenceX = Math.Abs(targetField.posX - startPos.posX) - 1;
                        int differenceY = Math.Abs(targetField.posY - startPos.posY) - 1;
                        //then return the larger one for x / y. this makes it work for any of the 8 directions
                        //Console.WriteLine("target is player, score is " + Math.Max(differenceX, differenceY));
                        int score = Math.Max(differenceX, differenceY);
                        return new BoardPosition(targetField.posX, targetField.posY, score);

                    //case empty: cancel and return score 0
                    case (EFieldState.empty):
                        return new BoardPosition(startPos.posX, startPos.posY, 0);

                }
            }
        }
    }
}