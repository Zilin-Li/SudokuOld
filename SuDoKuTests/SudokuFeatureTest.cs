using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SuDoKu;

namespace SuDoKuTests
{
    [TestClass]
    public class SudokuFeatureTest
    {
        [TestMethod]
        public void RowVaild_Test1()
        {
            bool expected = true;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[16];
            igame.sudokuArray[8] = 3;
            igame.sudokuArray[9] = 2;
            igame.sudokuArray[10] = 1;
            igame.sudokuArray[11] = 4;
            bool actual =igame.RowVaild(2);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ColumnVaild()
        {
            //test 6*6 third colum
            bool expected = true;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.sudokuArray = new int[36];
            igame.sudokuArray[2] = 3;
            igame.sudokuArray[8] = 2;
            igame.sudokuArray[14] = 1;
            igame.sudokuArray[20] = 4;
            igame.sudokuArray[26] = 6;
            igame.sudokuArray[32] = 5;
            bool actual = igame.ColumnVaild(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SquareVaild()
        {
            //test 9*9 second Square
            bool expected = true;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.squareHeight = 3;
            igame.squareWidth = 3;
            igame.sudokuArray = new int[81];
            igame.sudokuArray[3] = 6;
            igame.sudokuArray[4] = 5;
            igame.sudokuArray[5] = 1;
            igame.sudokuArray[12] = 7;
            igame.sudokuArray[13] = 2;
            igame.sudokuArray[14] = 9;
            igame.sudokuArray[21] = 3;
            igame.sudokuArray[22] = 8;
            igame.sudokuArray[23] = 4;
            bool actual = igame.SquareVaild(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VaildValueByRow()
        {
            var expected = new List<int>() {1,2 };
         
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[16];
            igame.sudokuArray[8] = 3;
            //igame.sudokuArray[9] = 2;
            //igame.sudokuArray[10] = 1;
            igame.sudokuArray[11] = 4;

            List<int> actual = igame.VaildValueByRow(9);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VaildValueByColumn()
        {
            var expected = new List<int>() { 3, 4, 6 };

            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.sudokuArray = new int[36];
            //igame.sudokuArray[2] = 3;
            igame.sudokuArray[8] = 2;
            igame.sudokuArray[14] = 1;
            //igame.sudokuArray[20] = 4;
            //igame.sudokuArray[26] = 6;
            igame.sudokuArray[32] = 5;

            List<int> actual = igame.VaildValueByColumn(20);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VaildValueBySquare1()
        {
            var expected = new List<int>() { 2,3,5 };

            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.squareHeight = 3;
            igame.squareWidth = 3;
            igame.sudokuArray = new int[81];

            igame.sudokuArray[3] = 6;
            //igame.sudokuArray[4] = 5;
            igame.sudokuArray[5] = 1;
            igame.sudokuArray[12] = 7;
            //igame.sudokuArray[13] = 2;
            igame.sudokuArray[14] = 9;
            //igame.sudokuArray[21] = 3;
            igame.sudokuArray[22] = 8;
            igame.sudokuArray[23] = 4;

            List<int> actual = igame.VaildValueBySquare(21);
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void VaildValueBySquare2()
        {
            //6*6, 3 high by 2 wide
            var expected = new List<int>() { 1, 4 };

            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.squareHeight = 3;
            igame.squareWidth = 2;
            igame.sudokuArray = new int[36];


            igame.sudokuArray[4] = 6;
            igame.sudokuArray[5] = 3;
            //igame.sudokuArray[10] = 1;
            //igame.sudokuArray[11] = 4;
            igame.sudokuArray[16] = 2;
            igame.sudokuArray[17] =5;
            List<int> actual = igame.VaildValueBySquare(11);
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void VaildValueBySquare3()
        {
            //6*6, 2 high by 3 wide
            var expected = new List<int>() { 1, 3, 5 };

            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.squareHeight = 2;
            igame.squareWidth = 3;
            igame.sudokuArray = new int[36];


            igame.sudokuArray[15] = 6;
            //igame.sudokuArray[16] = 3;
            //igame.sudokuArray[17] = 1;
            igame.sudokuArray[21] = 4;
            igame.sudokuArray[22] = 2;
            //igame.sudokuArray[23] = 5;
            List<int> actual = igame.VaildValueBySquare(23);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VaildValueBySquare4()
        {
            //4*4,
            var expected = new List<int>() {2, 3};

            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.squareHeight = 2;
            igame.squareWidth = 2;
            igame.sudokuArray = new int[16];


            //igame.sudokuArray[10] = 2;
            //igame.sudokuArray[11] = 3;
            igame.sudokuArray[14] = 1;
            igame.sudokuArray[15] = 4;
           
            List<int> actual = igame.VaildValueBySquare(11);
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
