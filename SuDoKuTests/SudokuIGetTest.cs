using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuDoKu;

namespace SuDoKuTests
{
    [TestClass]
    public class SudokuIGetTest
    {
        [TestMethod]
        public void GetByColumn_Test1()
        {
            // 4*4, test first cell
            int expected = 3;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[4 * 4];
            igame.sudokuArray[0] = 3;
            int actual = igame.GetByColumn(0, 0);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetByColumn_Test2()
        {
            //4*4 test last cell
            int expected = 4;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[4 * 4];
            igame.sudokuArray[15] = 4;
            int actual = igame.GetByColumn(3, 3);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetByColumn_Test3()
        {
            //6*6 test last cell
            int expected = 6;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.sudokuArray = new int[6 * 6];
            igame.sudokuArray[35] = 6;
            int actual = igame.GetByColumn(5, 5);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetByColumn_Test4()
        {
            //9*9 test last cell
            int expected = 9;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.sudokuArray = new int[9 * 9];
            igame.sudokuArray[80] = 9;
            int actual = igame.GetByColumn(8, 8);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetByRow_Test1()
        {
            //4*4 test last cell
            int expected = 4;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[4 * 4];
            igame.sudokuArray[15] = 4;
            int actual = igame.GetByRow(3, 3);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetByRow_Test2()
        {
            //6*6 test last cell
            int expected = 6;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.sudokuArray = new int[6 * 6];
            igame.sudokuArray[35] = 6;
            int actual = igame.GetByRow(5, 5);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetByRow_Test3()
        {
            //9*9 test last cell
            int expected = 9;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.sudokuArray = new int[9 * 9];
            igame.sudokuArray[80] = 9;
            int actual = igame.GetByRow(8, 8);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetBySquare_Test1()
        {
            //4*4 test last cell
            int expected = 4;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.squareWidth = 2;
            igame.squareHeight = 2;
            igame.sudokuArray = new int[4 * 4];
            igame.sudokuArray[15] = 4;
            int actual = igame.GetBySquare(3, 3);
            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void GetBySquare_Test2()
        {
            //6*6 test last cell
            int expected = 6;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.squareWidth = 2;
            igame.squareHeight = 3;
            igame.sudokuArray = new int[6 * 6];
            igame.sudokuArray[35] = 6;
            int actual = igame.GetBySquare(5, 5);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetBySquare_Test3()
        {
            //9*9 test last cell
            int expected = 9;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.squareWidth = 3;
            igame.squareHeight = 3;
            igame.sudokuArray = new int[9 * 9];
            igame.sudokuArray[80] = 9;
            int actual = igame.GetBySquare(8, 8);
            Assert.AreEqual(expected, actual);

        }

    }
}
