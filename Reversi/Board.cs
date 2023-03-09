﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    public enum EFieldState
    {
        empty,
        player1,
        player2
    }

    public class Board
    {
        //declaration of board
        public EFieldState[,] mBoard { get; private set; }

        public Board(int boardSizeX, int boardSizeY)
        {
            mBoard = new EFieldState[boardSizeX, boardSizeY];
        }

        public string ConvertBoardToText()
        {
            string outputString = "";
            //iterate through each row
            for (int yPos = 0; yPos < mBoard.GetLength(1); yPos++)
            {
                //iterate through each column
                for (int xPos = 0; xPos < mBoard.GetLength(0); xPos++)
                {
                    EFieldState currentFieldState = mBoard[xPos, yPos];
                    switch (currentFieldState)
                    {
                        case EFieldState.empty:
                            outputString += ". ";
                            break;
                        case EFieldState.player1:
                            outputString += "X ";
                            break;
                        case EFieldState.player2:
                            outputString += "O ";
                            break;
                    }
                }
            }
            return outputString;
        }

        public void ReadBoardFromText(string boardText)
        {
            //iterate through each row
            for (int yPos = 0; yPos < mBoard.GetLength(1); yPos++)
            {
                //iterate through each column
                for (int xPos = 0; xPos < mBoard.GetLength(0); xPos++)
                {
                    //get substring with first character
                    string currentFieldString = boardText.Substring(0, 1);
                    //convert string to EFieldState
                    switch (currentFieldString)
                    {
                        case ".":
                            EditBoardToken(xPos, yPos, EFieldState.empty);
                            break;
                        case "X":
                            EditBoardToken(xPos, yPos, EFieldState.player1);
                            break;
                        case "O":
                            EditBoardToken(xPos, yPos, EFieldState.player2);
                            break;
                        case "\n":
                            Console.WriteLine("new line");
                            break;
                    }
                    //remove first 2 characters from string to make next field be in front
                    boardText = boardText.Remove(0, 2);
                }
            }
        }

        public void EditBoardToken(int indexX, int indexY, EFieldState newState)
        {
            mBoard[indexX, indexY] = newState;
        }

        public void PrintBoardToConsole()
        {
            string boardString = ConvertBoardToText();

            for (int row = 0; row < mBoard.GetLength(1); row++)
            {
                Console.WriteLine(boardString.Substring(row * mBoard.GetLength(0) * 2, mBoard.GetLength(0) * 2));
            }
        }
    }
}
