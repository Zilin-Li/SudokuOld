using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
     public partial class SudokuGame : ISet
    {
        public int arrayIndex;
        public int[] sudokuArray, CSVArray;
        public int maxValue;
        public int squareHeight;
        public int squareWidth;
        public string CSVFile;
        public string PrettyString;
        public int cellValue;


        //Realize interface ISet.
        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            
            if (value >= 0 && value <= maxValue && rowIndex >= 0 && rowIndex < maxValue && columnIndex >= 0 && columnIndex < maxValue)
            {
                arrayIndex = columnIndex + rowIndex * maxValue;
                sudokuArray[arrayIndex] = value;
            }
            else
            {
                Console.WriteLine("Out of range!");
            }
 
        }
        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            
            if (value >= 0 && value <= maxValue && rowIndex >= 0 && rowIndex < maxValue && columnIndex >= 0 && columnIndex < maxValue)
            {
                arrayIndex = columnIndex + rowIndex * maxValue;
                sudokuArray[arrayIndex] = value;
            }
            else
            {
                Console.WriteLine("Out of range!");
            }
        }
        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            int colInd;
            int rowInd;
            if (value >= 0 && value <= maxValue && squareIndex >= 0 && squareIndex < maxValue && positionIndex >= 0 && positionIndex < maxValue)
            {
                // Use squareIndex and positionIndex to find out the colindex and rowindex
                // use colindex and rowindex to set the value
                colInd = (squareIndex % (maxValue / squareWidth)) * squareWidth + (positionIndex % squareWidth);
                rowInd = (squareIndex / (maxValue / squareWidth)) * squareHeight + (positionIndex / squareWidth);
                arrayIndex = colInd + rowInd * maxValue;
                sudokuArray[arrayIndex] = value;
            }
            else
            {
                Console.WriteLine("Out of range!");
            }
        }
    }
}



