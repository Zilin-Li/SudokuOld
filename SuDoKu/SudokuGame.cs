using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
    class SudokuGame : ISet, IGame, IGet, ISerialize
    {
        private int arrayIndex;
        private int[] sudokuArray,mySudokuArray; // = new int[100];
        private int maxValue; // = 6;
        private int squareHeight; // = 2;
        private int squareWidth; // = 3
        private string CSVFile;
        private string PrettyString;
        protected int cellValue;


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
            rowInd = (squareIndex / (maxValue / squareWidth)) * squareHeight + (positionIndex / squareWidth);
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
            return maxValue;
        }

        //We get a string "CSVFile", Which including ',' and '\n'
        //This function to change the string to an int[], Which we can use to set the cellvalue.
        public int[] ToArray()
        {
            //trans the CSVFile into a string which only including cellvalue.
            string cellValueStr = "";
            for (int i = 0; i < CSVFile.Length; i++)
            {
                if (Char.IsNumber(CSVFile, i) == true)
                {
                    cellValueStr += CSVFile.Substring(i, 1);
                }
            }
            // put the cellvalue into a int array.

            sudokuArray = new int[cellValueStr.Length];
            for (int i = 0; i < cellValueStr.Length; i++)
                sudokuArray[i] = Int32.Parse(cellValueStr[i].ToString());

            return sudokuArray;
        }


        public void Set(int[] cellValues)
        {
            sudokuArray = cellValues;
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



        }

        //Realize interface ISerialize
        public void FromCSV(string csv)
        {
            CSVFile = csv;
        }

        public string ToCSV() //the function to save the game;
        {
            string saveFile = "";
            for (int i = 0; i < sudokuArray.Length; i++)
            {
                saveFile += sudokuArray[i] + ",";
            }
            saveFile += '\n';

            return saveFile;

        }
        public void SetCell(int value, int gridIndex)
        {
            this.ToArray()[gridIndex] = value;
        }
        public int GetCell(int gridIndex)
        {
            cellValue = this.ToArray()[gridIndex];
            return cellValue;
        }

        public string ToPrettyString()
        {
            PrettyString = "";
            for (int i = 0; i < maxValue * maxValue; i++)
            {
                //cellArray[i] = 7;
                if ((i + 1) % maxValue == 0)
                {
                    PrettyString += " " + sudokuArray[i].ToString();
                    PrettyString += "\n";
                }
                else
                {
                    if ((i + 1) % squareWidth == 0)
                    {
                        PrettyString += " " + sudokuArray[i].ToString() + " |";
                    }
                    else
                    {
                        PrettyString += " " + sudokuArray[i].ToString();
                    }
                }

                if ((i + 1) % (squareHeight * maxValue) == 0 && (i + 1) % (maxValue * maxValue) != 0)
                {
                    for (int j = 0; j < maxValue / squareWidth; j++)
                    {
                        for (int k = 0; k < squareWidth * 2 + 1; k++)
                        {
                            PrettyString += "-";
                        }
                        if (j != maxValue / squareWidth - 1)
                        {
                            PrettyString += "+";
                        }
                    }
                    PrettyString += "\n";
                }

            }
            return PrettyString;
        }

            //Other features
            public bool rowVaild(int RowNumber)
            {
                int[] cellValue = { 1, 0, 2, 0, 2, 4, 3, 1, 4, 2, 1, 3, 3, 1, 4, 2 };
                int maxValue = 4;
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



