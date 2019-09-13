using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
    class SudokuGame : ISet, IGame, IGet, ISerialize
    {
        private int arrayIndex;
        private int[] sudokuArray; // = new int[100];
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
            int colInd;
            int rowInd;
            // Use squareIndex and positionIndex to find out the colindex and rowindex
            // use colindex and rowindex to set the value
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
        //This function to change the string to an int[]
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

            int[] mySudokuArray = new int[cellValueStr.Length];
            for (int i = 0; i < cellValueStr.Length; i++)
                mySudokuArray[i] = Int32.Parse(cellValueStr[i].ToString());

            return mySudokuArray;
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

        //the function to save the game;
        //change the current sudoku array to CSVfile(a string)
        public string ToCSV() 
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
            sudokuArray[gridIndex] = value;
        }
        public int GetCell(int gridIndex)
        {
            cellValue = sudokuArray[gridIndex];
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

        //feature 1: check whether a row is vaild.
        public bool RowVaild(int RowNumber)
        {
            bool isVaildRow = true;

            int[] rowValue = new int[maxValue];
        //put every value of the row into an int array.
        //for next step to check
            for (int i = 0; i < maxValue; i++)
            {
                rowValue[i] = GetByRow(RowNumber, i);
            }

        //sort the value, the vaild value should be 1~maxValue.
        //if not return false.

            Array.Sort(rowValue);
            for (int a = 0; a < maxValue; a++)
            {
                if(rowValue[a] != a+1)
                {
                isVaildRow = false;
                }
            }
                    
            return isVaildRow;
        }

        //feature 2: check whether a column is vaild.
        public bool ColumnVaild(int ColumnNumber)
        {
            bool isVaildColumn = true;

            int[] ColumnValue = new int[maxValue];
            //put each value of the Column into an int array.
            //for next step to check
            for (int i = 0; i < maxValue; i++)
            {
                ColumnValue[i] = GetByColumn(ColumnNumber, i);
            }

            //sort the value, the vaild value should be 1~maxValue.
            //if not return false.

            Array.Sort(ColumnValue);
            for (int a = 0; a < maxValue; a++)
            {
                if (ColumnValue[a] != a + 1)
                {
                    isVaildColumn = false;
                }
            }
            return isVaildColumn;
        }

        //feature 3: check whether a square is vaild.
        public bool SquareVaild(int squareNumber)
        {
            bool isVaildSquare = true;

            int[] SquareValue = new int[maxValue];
            //put every value of the Square into an int array.
            //for next step to check
            for (int i = 0; i < maxValue; i++)
            {
                SquareValue[i] = GetBySquare(squareNumber, i);
            }

            //sort the value, the vaild value should be 1~maxValue.
            //if not return false.

            Array.Sort(SquareValue);
            for (int a = 0; a < maxValue; a++)
            {
                if (SquareValue[a] != a + 1)
                {
                    isVaildSquare = false;
                }
            }
            return isVaildSquare;
        }

        //feature 4: list vaild value by Row.

        public List<int> VaildValueByRow(int gridIndex)
        {

            //step1: put all value(1-maxvalue) into list.
            List<int> rowVaildValue = new List<int>();
            for(int i = 1; i <= maxValue; i++)
            {
                rowVaildValue.Add(i);
            }

            // get the rowIndex
            int rowIndex = gridIndex / maxValue;

            //step2: use get GetByRow() to get each value of the row
            for (int a = 0; a < maxValue; a++)
            {
                int eachRowValue = GetByRow(rowIndex, a);

                //step3: check whether the rowvalue in the list
                //if already in the list, remove it.
                //the remain number is vaild value.
                if (rowVaildValue.Contains(eachRowValue))
                {
                    rowVaildValue.Remove(eachRowValue);
                }

            }
            return rowVaildValue;
        }

        //feature 5: list vaild value by Column.

        public List<int> VaildValueByColumn(int gridIndex)
        {

            //step1: put all value(1-maxvalue) into list.
            List<int> ColumnVaildValue = new List<int>();
            for (int i = 1; i <= maxValue; i++)
            {
                ColumnVaildValue.Add(i);
            }

            // get the columnIndex
            int columnIndex = gridIndex % maxValue;

            //step2: use get GetByColumn() to get each value of the Column
            for (int a = 0; a < maxValue; a++)
            {
                int eachColumnValue = GetByColumn(columnIndex, a);

                //step3: check whether the rowvalue in the list
                //if already in the list, remove it.
                //the remain number is vaild value.
                if (ColumnVaildValue.Contains(eachColumnValue))
                {
                    ColumnVaildValue.Remove(eachColumnValue);
                }

            }
            return ColumnVaildValue;
        }

        //feature 6: list vaild value by Square.

        public List<int> VaildValueBySquare(int gridIndex)
        {

            //step1: put all value(1-maxvalue) into list.
            List<int> squareVaildValue = new List<int>();
            for (int i = 1; i <= maxValue; i++)
            {
                squareVaildValue.Add(i);
            }

            // get the squareIndex
            int columnIndex = gridIndex % maxValue;
            int rowIndex = gridIndex / maxValue;
            int squareIndex = (rowIndex / squareHeight) * squareHeight + columnIndex % squareWidth;


            //step2: use get GetBySquare() to get each value of the square
            for (int a = 0; a < maxValue; a++)
            {
                int eachSquareValue = GetBySquare(squareIndex, a);

                //step3: check whether the squarevalue in the list
                //if already in the list, remove it.
                //the remain number is vaild value.
                if (squareVaildValue.Contains(eachSquareValue))
                {
                    squareVaildValue.Remove(eachSquareValue);
                }

            }
            return squareVaildValue;
        }



    }
}



