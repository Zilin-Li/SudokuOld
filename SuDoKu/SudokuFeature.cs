﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
    public partial class SudokuGame
    {
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
                if (rowValue[a] != a + 1)
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
            for (int i = 1; i <= maxValue; i++)
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

           // get the squareIndex   *****************************incorrect
            int columnIndex = gridIndex % maxValue;
            int rowIndex = gridIndex / maxValue;
            int squareIndex = (rowIndex / squareHeight) * squareHeight + columnIndex % squareWidth;


            //use below method to get squreIndex *********************************************************
            for(int i=0; i< maxValue; i++)
            {
                for(int j= 0; j< maxValue; j++)
                {
                    if((i  * maxValue) + j == gridIndex)
                        squareIndex = i / squareHeight * squareHeight + j / squareWidth;
                }
            }




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
