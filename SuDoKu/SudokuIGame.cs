using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
    public partial class SudokuGame :IGame
    {
        //Realize interface IGame.
        public void SetMaxValue(int maximum)
        {
            maxValue = maximum;
        }
        public int GetMaxValue()
        {
            int Value = CSVArray[0];
            return Value;
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

            CSVArray = new int[cellValueStr.Length];
            for (int i = 0; i < cellValueStr.Length; i++)
                CSVArray[i] = Int32.Parse(cellValueStr[i].ToString());

            return CSVArray;
        }


        public void Set(int[] cellValues)
        {
            sudokuArray = new int[maxValue*maxValue];

            for(int i = 0; i < maxValue * maxValue; i++)
            {
                sudokuArray[i] = cellValues[i+3];
            }

        }
        public int GetSquareWidth()
        {
            int Width = CSVArray[1];
            return Width;
        }
        public void SetSquareWidth(int Width)
        {
            squareWidth = Width;
        }

        public int GetSquareHeight()
        {
            int Height = CSVArray[2];
            return Height;
        }
        public void SetSquareHeight(int Height)
        {
            squareHeight = Height;
        }

        public void Restart()
        {
            this.Set(this.ToArray());

        }

    }
}
