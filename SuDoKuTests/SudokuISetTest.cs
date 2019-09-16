using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuDoKu;

namespace SuDoKuTests
{
    [TestClass]
    public class SudokuISetTest
    {
        [TestMethod]
        public void SetByColumn_Test1()
        {
            // set last cell on 4*4 
            int expected = 4;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[16];
            igame.SetByColumn(4, 3, 3);
            int actual = igame.sudokuArray[15];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByColumn_Test2()
        {
            // set first cell on 4*4 
            int expected = 1;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[16];
            igame.SetByColumn(1, 0, 0);
            int actual = igame.sudokuArray[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByColumn_Test3()
        {
            // set middle cell on 4*4 
            int expected = 2;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[16];
            igame.SetByColumn(2, 2, 2);
            int actual = igame.sudokuArray[10];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByColumn_Test4()
        {
            // set last cell on 6*6 
            int expected = 6;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.sudokuArray = new int[36];
            igame.SetByColumn(6, 5, 5);
            int actual = igame.sudokuArray[35];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByColumn_Test5()
        {
            // set first cell on 6*6 
            int expected = 1;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.sudokuArray = new int[36];
            igame.SetByColumn(1, 0, 0);
            int actual = igame.sudokuArray[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByColumn_Test6()
        {
            // set last cell on 9*9 
            int expected = 9;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.sudokuArray = new int[81];
            igame.SetByColumn(9, 8, 8);
            int actual = igame.sudokuArray[80];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByColumn_Test7()
        {
            // set first cell on 9*9 
            int expected = 1;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.sudokuArray = new int[81];
            igame.SetByColumn(1, 0, 0);
            int actual = igame.sudokuArray[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByRow_Test1()
        {
            // set first cell on 4*4
            int expected = 1;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[16];
            igame.SetByColumn(1, 0, 0);
            int actual = igame.sudokuArray[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByRow_Test2()
        {
            // set last cell on 4*4
            int expected = 4;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[16];
            igame.SetByColumn(4, 3, 3);
            int actual = igame.sudokuArray[15];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByRow_Test3()
        {
            // set first cell on 6*6
            int expected = 1;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.sudokuArray = new int[36];
            igame.SetByColumn(1, 0, 0);
            int actual = igame.sudokuArray[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByRow_Test4()
        {
            // set last cell on 6*6
            int expected = 6;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.sudokuArray = new int[36];
            igame.SetByColumn(6, 5, 5);
            int actual = igame.sudokuArray[35];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByRow_Test5()
        {
            // set first cell on 9*9
            int expected = 1;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.sudokuArray = new int[81];
            igame.SetByColumn(1, 0, 0);
            int actual = igame.sudokuArray[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetByRow_Test6()
        {
            // set last cell on 9*9
            int expected = 9;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.sudokuArray = new int[81];
            igame.SetByColumn(9, 8, 8);
            int actual = igame.sudokuArray[80];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetBySquare_Test()
        {
            // set last cell on 4*4
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.squareWidth = 2;
            igame.squareHeight = 2;
            igame.sudokuArray = new int[16];
            //set value as:
            //0123
            //0123
            //0123
            //0123

            //row
            for (int i=0; i<4; i++)
            {
                //colum
                for(int j=0; j < 4; j++)
                {
                    int SquareIndex = i / 2 * 2 + j / 2;
                    igame.SetBySquare(j, SquareIndex, j%2 + i % 2 *2);
                }
            }
            
            //test value
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(j, igame.sudokuArray[i*4 +j]);
                }
            }
        }







    }
}
