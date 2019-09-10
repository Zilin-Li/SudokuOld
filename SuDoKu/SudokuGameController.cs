using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
    class SudokuGameController
    {
        protected IView view;
        protected SudokuGame game;

        public SudokuGameController(IView theView, SudokuGame theGame)
        {
            view = theView;
            game = theGame;
        }

        public void Go()
        {
            int[] inputData = new int[3];       // Data from user

            // Load and display a dummy CSVFile
            string CSVFile = "";
            // 2 by 2 file
            CSVFile = "4,2,2" + '\n';
            CSVFile += ("1,0,3,4,2,3,0,1,0,4,1,2,0,1,2,0" + '\n');
            // section 2 high by 3 wide file
            CSVFile = "6,2,3" + '\n';
            CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');
            // section 3 high by 2 wide file
            /*CSVFile = "6,3,2" + '\n';
            CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');
            // 3 by 3 file
            /* CSVFile = "9,3,3" + '\n';
            CSVFile += ("1,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,1,3,4,5,6,7,8,9,1,2,4,5,6,7,8,9,1,2,3,5,6,7,8,9,1,2,3,4,6,7,8,9,1,2,3,4,5,7,8,9,1,2,3,4,5,6,8,9,1,2,3,4,5,6,7,9,1,2,3,4,5,6,7,8" + '\n');
            */
            game.FromCSV(CSVFile);
            view.Clear();
            view.DisplayBoard(game.ToPrettyString());
            // Allow some editing
            inputData = view.GetCellChangeData("Enter row, col, value. (-1 to finish)");
            while (inputData[0] != -1)
            {
                game.SetByRow(inputData[2], inputData[0], inputData[1]);
                view.DisplayBoard(game.ToPrettyString());
                inputData = view.GetCellChangeData("Enter row, cell, value. (-1 to finish)");
            }
            view.Finish();
        }
    }
}
