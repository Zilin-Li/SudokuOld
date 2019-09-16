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
        protected string vaildValue;
        //protected int[] cellValueArray;

        public SudokuGameController(IView theView, SudokuGame theGame)
        {
            view = theView;
            game = theGame;
        }

        public void Go()
        {
            int[] inputData = new int[3];       // Data from user

            //test1: base on 4 by 4 game.

            //Initialize game Settings

            // Load and display a dummy CSVFile

            string CSVFile = "";

            // 2 by 2 file
            CSVFile = "4,2,2" + '\n';
            CSVFile += ("1,0,3,4,2,3,0,1,0,4,1,2,0,1,2,0" + '\n');

            // section 2 high by 3 wide file
            //CSVFile = "6,2,3" + '\n';
            //CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');

            // section 3 high by 2 wide file
            //CSVFile = "6,3,2" + '\n';
            //CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');

            // 3 by 3 file
            //CSVFile = "9,3,3" + '\n';
            //CSVFile += ("1,2,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,1,3,4,5,6,7,8,9,1,2,4,5,6,7,8,9,1,2,3,5,6,7,8,9,1,2,3,4,6,7,8,9,1,2,3,4,5,7,8,9,1,2,3,4,5,6,8,9,1,2,3,4,5,6,7,9,1,2,3,4,5,6,7,8" + '\n');

            game.FromCSV(CSVFile); // test: ISerialize - FromCSV
            game.ToArray();

            maxValue = game.GetMaxValue();
            SquareHeight = game.GetSquareHeight();
            SquareWidth = game.GetSquareWidth();

            game.SetMaxValue(maxValue); // test: IGame - SetMaxValue
            game.SetSquareHeight(SquareHeight);//test: IGame - SetSquareHeight
            game.SetSquareWidth(SquareWidth); //test: IGame - SetSquareWidth
            game.Set(game.ToArray()); // test: IGame - ToArray,Set

            view.Clear();

            //Output the sudoku game(4*4)
            view.DisplayBoard(game.ToPrettyString()); // test: ISerialize - ToPrettyString
            game.ToCSV();
            //test: ISerialize - SetCell
             Console.WriteLine("test: ISerialize - SetCell: ");
             inputData = view.GetCellChangeData("Enter value, cellIndex.");
             game.SetCell(inputData[0], inputData[1]); 
             Array.Clear(inputData, 0, inputData.Length);
             view.DisplayBoard(game.ToPrettyString());
             view.DisplayBoard("---------------------------");

             //test: ISerialize - GetCell
             Console.WriteLine("test: ISerialize - GetCell: ");
             inputData = view.GetCellChangeData("Enter cellIndex.");
             view.DisplayBoard("The cell value is " + game.GetCell(inputData[0]).ToString()); 
             Array.Clear(inputData, 0, inputData.Length);
             view.DisplayBoard(game.ToPrettyString());
             view.DisplayBoard("---------------------------");

             //test: ISerialize - ToCSV
             Console.WriteLine("test: ISerialize - ToCSV: ");
             view.DisplayBoard(game.ToCSV());
            view.DisplayBoard(game.ToPrettyString());
            view.DisplayBoard("---------------------------");
            Console.ReadLine();

            //test: test: IGame - Restart

            Console.WriteLine("Press any key to restart.--This is a test.");
            Console.ReadLine();
            game.Restart();
            view.DisplayBoard(game.ToPrettyString());

            //test the function of ISet.

            //test: ISet - SetByRow
            Console.WriteLine("test: ISet - SetByRow: ");
             inputData = view.GetCellChangeData("Enter row, col, value.");
             game.SetByRow(inputData[2], inputData[0], inputData[1]);
             view.DisplayBoard(game.ToPrettyString());
             view.DisplayBoard("---------------------------");

             //test: ISet - SetByColumn
             Console.WriteLine("test: ISet - SetByColumn: ");
             inputData = view.GetCellChangeData("Enter row, col, value.");
             game.SetByRow(inputData[2], inputData[0], inputData[1]);
             view.DisplayBoard(game.ToPrettyString());
             view.DisplayBoard("---------------------------");

             //test: ISet - SetBySquare
             Console.WriteLine("test: ISet - SetBySquare: ");
             inputData = view.GetCellChangeData("Enter squareIndex, positionIndex, value.");
             game.SetBySquare(inputData[2], inputData[0], inputData[1]);
             view.DisplayBoard(game.ToPrettyString());
             view.DisplayBoard("---------------------------");


             //test the function of IGet.

             //test: IGet - GetByColumn
             Console.WriteLine("test: IGet - GetByColumn: ");
             inputData = view.GetCellChangeData("Enter row, col");
             view.DisplayBoard("The cell value is " + game.GetByColumn(inputData[1], inputData[0]).ToString());
             Array.Clear(inputData, 0, inputData.Length);
             view.DisplayBoard(game.ToPrettyString());
             view.DisplayBoard("---------------------------");


             //test: IGet - GetByRow
             Console.WriteLine("test: IGet - GetByRow: ");
             inputData = view.GetCellChangeData("Enter row, col");
             view.DisplayBoard("The cell value is " + game.GetByRow(inputData[0], inputData[1]).ToString());
             Array.Clear(inputData, 0, inputData.Length);
             view.DisplayBoard(game.ToPrettyString());
             view.DisplayBoard("---------------------------");


             //test: IGet - GetBySquare
             Console.WriteLine("test: IGet - GetBySquare: ");
             inputData = view.GetCellChangeData("Enter squareIndex, positionIndex");
             view.DisplayBoard("The cell value is " + game.GetBySquare(inputData[0], inputData[1]).ToString());
             Array.Clear(inputData, 0, inputData.Length);
             view.DisplayBoard(game.ToPrettyString());
             view.DisplayBoard("---------------------------");




             //test the function of RowVaild

             Console.WriteLine("test: SudokuFeature - RowVaild: ");

             for (int i = 0; i < maxValue; i++)
             {
                 bool isRowValid = game.RowVaild(i);

                 if (isRowValid)
                 {
                     Console.WriteLine("Row " + i + " is valid.");
                 }
                 else
                 {
                     Console.WriteLine("Row " + i + " is NOT valid.");
                 }
             }

             //test the function of ColumnVaild
             Console.WriteLine("test: SudokuFeature - ColumnVaild: ");
             for (int i = 0; i < maxValue; i++)
             {
                 bool isColumnValid = game.ColumnVaild(i);

                 if (isColumnValid)
                 {
                     Console.WriteLine("Column " + i + " is valid.");
                 }
                 else
                 {
                     Console.WriteLine("Column " + i + " is NOT valid.");
                 }
             }

             //test the function of SquareVaild

             Console.WriteLine("test: SudokuFeature - SquareVaild: ");
             for (int i = 0; i < maxValue; i++)
             {
                 bool isSquareValid = game.SquareVaild(i);

                 if (isSquareValid)
                 {
                     Console.WriteLine("Square " + i + " is valid.");
                 }
                 else
                 {
                     Console.WriteLine("Square " + i + " is NOT valid.");
                 }
             }


            //test the function of VaildValueByRow

            vaildValue = "";
            Console.WriteLine("Enter the cell index to check the Row vaild value.");
  
            List<int> RowPossible = game.VaildValueByRow(Int16.Parse(Console.ReadLine()));

            foreach (int aNumber in RowPossible)
            {
                vaildValue += aNumber + " ";
            }

            Console.Write("Row vaild value list: < " + vaildValue +">");
            Console.Write("\n");

            //test the function of VaildValueByColumn

            vaildValue = "";
            Console.WriteLine("Enter the cell index to check the Column vaild value.");

            List<int> ConlumnPossible = game.VaildValueByColumn(Int16.Parse(Console.ReadLine()));
            foreach (int aNumber in ConlumnPossible)
            {
                vaildValue += aNumber + " ";
            }

            Console.Write("Conlumn vaild value list: < " + vaildValue + ">");
            Console.Write("\n");

            //test the function of VaildValueBySquare

            vaildValue = "";
            Console.WriteLine("Enter the cell index to check the Square vaild value.");
            List<int> SquarePossible = game.VaildValueBySquare(Int16.Parse(Console.ReadLine()));
            foreach (int aNumber in SquarePossible)
            {
                vaildValue += aNumber + " ";
            }

            Console.Write("Square vaild value list: < " + vaildValue + ">");
            Console.Write("\n");



            view.Finish();
        }
    }
}

