using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SuDoKu
{
    public partial class SudokuGame : ISerialize
    {
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

            var csv = new StringBuilder();
            csv.AppendLine(saveFile);
            //get current working directory
            string path = Directory.GetCurrentDirectory();
            string filePath = path + "/mysudoku.csv";
            File.WriteAllText(filePath, csv.ToString());
            return saveFile;
        }

        public void SetCell(int value, int gridIndex)
        {
            if(value>=0 && value<= maxValue && gridIndex >=0 && gridIndex < maxValue * maxValue)
            {
                sudokuArray[gridIndex] = value;
            }
            else
            {
                Console.WriteLine("Out of range");
            }
            
        }
        public int GetCell(int gridIndex)
        {
            if(gridIndex>=0 && gridIndex< maxValue * maxValue)
            {
                cellValue = sudokuArray[gridIndex];
            }

            else
            {
                cellValue = 0;
            }
            
            return cellValue;
        }

        public string ToPrettyString()
        {
            PrettyString = "";

            // This part was wrote by Harry
            for (int i = 0; i < maxValue * maxValue; i++)
            {
            
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

            }// End here.

            PrettyString = PrettyString.Replace('0', '*');
            return PrettyString;
        }
    }
}
