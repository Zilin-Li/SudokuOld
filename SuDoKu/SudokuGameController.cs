using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
    class SudokuGameController
    {
        protected IView view;
        protected SudokuGame game;
        protected int maxValue, SquareHeight, SquareWidth;
        protected int[] cellValueArray;

        public SudokuGameController(IView theView, SudokuGame theGame)
        {
            view = theView;
            game = theGame;
        }

        public void Go()
        {
            int[] inputData = new int[3];       // Data from user

            //test1 

            maxValue = 4;
            SquareHeight = 2;
            SquareWidth = 2;
            //Initialize game Settings

            game.SetMaxValue(maxValue);
            game.SetSquareHeight(SquareHeight);
            game.SetSquareWidth(SquareWidth);

            // Load and display a dummy CSVFile
            string CSVFile = "";

            // 2 by 2 file
            CSVFile = "4,2,2" + '\n';
            CSVFile += ("1,0,3,4,2,3,0,1,0,4,1,2,0,1,2,0" + '\n');

          
            game.FromCSV(CSVFile);
            view.Clear();

            //Output the sudoku game(4*4)
            cellValueArray = new int[maxValue* maxValue];
            cellValueArray = game.ToArray();
            view.DisplayBoard(game.ToPrettyString());

            //test the function of ISet.

            //SetByRow(row 1,col 0,value 1)
            /*inputData = view.GetCellChangeData("Enter row, col, value. (-1 to finish)");
            game.SetByRow(inputData[2], inputData[0], inputData[1]);
            view.DisplayBoard(game.ToPrettyString());*/

            //SetByColumn(row2, cole1, value4)
            /*inputData = view.GetCellChangeData("Enter row, col, value. (-1 to finish)");
            game.SetByRow(inputData[2], inputData[0], inputData[1]);
            view.DisplayBoard(game.ToPrettyString());*/

            //SetBySquare(row2, cole1, value4)
            /*inputData = view.GetCellChangeData("Enter squareIndex, positionIndex, value. (-1 to finish)");
            game.SetBySquare(inputData[2], inputData[0], inputData[1]);
            view.DisplayBoard(game.ToPrettyString());*/

            //test the function of IGet.

            //GetByColumn
            /*inputData = view.GetCellChangeData("Enter row, col");
             view.DisplayBoard("The cell value is " + game.GetByColumn(inputData[1], inputData[0]).ToString());
             Array.Clear(inputData, 0, inputData.Length);

             //GetByRow
             inputData = view.GetCellChangeData("Enter row, col");
             view.DisplayBoard("The cell value is " + game.GetByRow(inputData[0], inputData[1]).ToString());
             Array.Clear(inputData, 0, inputData.Length);

             //GetBySquare
             inputData = view.GetCellChangeData("Enter squareIndex, positionIndex");
             view.DisplayBoard("The cell value is " + game.GetBySquare(inputData[0], inputData[1]).ToString());
             Array.Clear(inputData, 0, inputData.Length);*/

            /*inputData = view.GetCellChangeData("Enter row, cell, value. (-1 to finish)");
            while (inputData[0] != -1)
            {

                game.SetByRow(inputData[2], inputData[0], inputData[1]);

                view.DisplayBoard(game.ToPrettyString());
                
                inputData = view.GetCellChangeData("Enter row, cell, value. (-1 to finish)");
            }
            // test the function of ToCSV
           view.DisplayBoard(game.ToCSV());*/
            

            //test the function of SetCell/GetCell
            /*game.SetCell(3, 4);
            view.DisplayBoard(game.ToPrettyString());
            view.DisplayBoard(game.GetCell(9).ToString());*/

            view.Finish();
        }
    }
}

/* while (inputData[0] != -1)
            {
                game.SetByRow(inputData[2], inputData[0], inputData[1]);
                view.DisplayBoard(game.ToPrettyString());
                inputData = view.GetCellChangeData("Enter row, cell, value. (-1 to finish)");
            }
            */

// section 2 high by 3 wide file
//CSVFile = "6,2,3" + '\n';
//CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');
// section 3 high by 2 wide file
/*CSVFile = "6,3,2" + '\n';
CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');
// 3 by 3 file
/* CSVFile = "9,3,3" + '\n';
CSVFile += ("1,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,1,3,4,5,6,7,8,9,1,2,4,5,6,7,8,9,1,2,3,5,6,7,8,9,1,2,3,4,6,7,8,9,1,2,3,4,5,7,8,9,1,2,3,4,5,6,8,9,1,2,3,4,5,6,7,9,1,2,3,4,5,6,7,8" + '\n');
*/
