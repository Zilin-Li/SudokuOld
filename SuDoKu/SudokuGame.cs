using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
    class SudokuGame : ISet, IGame, IGet, ISerialize
    {
        public int arrayIndex;
        public int[] sudokuArray; // = new int[100];
        public int maxValue; // = 6;
        public int squareHeight; // = 2;
        public int squareWidth; // = 3;

        public SudokuGame(int newMaximum, int newSquareHeight, int newSquareWidth, int[] newSudokuArray)
        {
            maxValue = newMaximum;
            squareHeight = newSquareHeight;
            squareWidth = newSquareWidth;
            sudokuArray = newSudokuArray;
        }

        //Realize interface ISet.
        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            arrayIndex = columnIndex + rowIndex * maxValue;
            sudokuArray[arrayIndex] = value;
        }
        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            arrayIndex = columnIndex + rowIndex * maxValue;
            sudokuArray[arrayIndex] = value;
        }
        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            int colInd;//local columnIndex
            int rowInd;//local rowIndex
            colInd = (squareIndex % (maxValue / squareWidth)) * squareWidth + (positionIndex % squareWidth);
            rowInd = (squareIndex / (maxValue / squareWidth)) * squareHeight + (positionIndex % squareWidth);
            arrayIndex = colInd + rowInd * maxValue;
            sudokuArray[arrayIndex] = value;
        }

        //Realize interface IGet.
        public int GetByColumn(int columnIndex, int rowIndex)
        {
            arrayIndex = columnIndex + rowIndex * maxValue;
            return sudokuArray[arrayIndex];
        }
        public int GetByRow(int rowIndex, int columnIndex)
        {
            arrayIndex = columnIndex + rowIndex * maxValue;
            return sudokuArray[arrayIndex];
        }
        public int GetBySquare(int squareIndex, int positionIndex)
        {
            int colInd;//local columnIndex
            int rowInd;//local rowIndex
            colInd = (squareIndex % (maxValue / squareWidth)) * squareWidth + (positionIndex % squareWidth);
            rowInd = (squareIndex / (maxValue / squareWidth)) * squareHeight + (positionIndex / squareWidth);
            arrayIndex = colInd + rowInd * maxValue;
            return sudokuArray[arrayIndex];
        }

        //Realize interface IGame.
        public void SetMaxValue(int maximum)
        {
            maxValue = maximum;
        }
        public int GetMaxValue()
        {

            Console.WriteLine("Please enter the max value: ");
            return Int16.Parse(Console.ReadLine());
        }
        public int[] ToArray()
        {
            sudokuValue = new int[maxValue * maxValue];
            for (int i = 0; i < maxValue * maxValue; i++)
            {
                sudokuValue[i] = 0;
            }

            return sudokuValue;

        }
        public void Set(int[] cellValues)
        {

        }
        public void SetSquareWidth(int Width)
        {
            squareWidth = Width;
        }
        public void SetSquareHeight(int Height)
        {
            squareHeight = Height;
        }
        public void Restart()
        {
            string result = "";

            for (int i = 0; i < maxValue * maxValue; i++)
            {
                if ((i + 1) % maxValue == 0)
                {
                    result += " " + sudokuValue[i].ToString();
                    result += "\n";
                }
                else
                {
                    if ((i + 1) % squareWidth == 0)
                    {
                        result += " " + sudokuValue[i].ToString() + " |";
                    }
                    else
                    {
                        result += " " + sudokuValue[i].ToString();
                    }
                }

                if ((i + 1) % (squareHeight * maxValue) == 0 && (i + 1) % (maxValue * maxValue) != 0)
                {
                    for (int j = 0; j < maxValue / squareHeight; j++)
                    {
                        for (int k = 0; k < squareHeight * 2 + 1; k++)
                        {
                            result += "-";
                        }
                        if (j != maxValue / squareHeight - 1)
                        {
                            result += "+";
                        }
                    }
                    result += "\n";
                }
            }
            Console.WriteLine(result);

        }

        public bool rowVaild(int RowNumber)
        {
            int[] cellValue = { 1, 0, 2, 0, 2, 4, 3, 1, 4, 2, 1, 3, 3, 1, 4, 2 };
            int maxValue = 4;
            int Width = 2;
            int Height = 2;
            int[] rowValue = new int[maxValue];



            for (int i = 0; i < maxValue; i++)
            {

                rowValue[i] = cellValue[RowNumber * maxValue + i];
            }

            for (int a = 1; a <= 4; a++)
            {
                int id = Array.IndexOf(rowValue, a);
                if (id == -1)
                {
                    return false;
                }
            }
            return true;
        }



    }

}
