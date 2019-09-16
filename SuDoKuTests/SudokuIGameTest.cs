using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuDoKu;

namespace SuDoKuTests
{
    [TestClass]
    public class SudokuIGameTest
    {
        [TestMethod]
        public void SetMaxValue_Test1()
        {
            //test SetMaxValue when maxValue equal 3
            int expected = 3;
            SudokuGame igame = new SudokuGame();
            igame.SetMaxValue(3);
            int actual = igame.maxValue;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void SetMaxValue_Test2()
        {
            //test SetMaxValue when maxValue equal 6
            int expected = 6;
            SudokuGame igame = new SudokuGame();
            igame.SetMaxValue(6);
            int actual = igame.maxValue;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void SetMaxValue_Test3()
        {
            //test SetMaxValue when maxValue equal 9
            int expected = 9;
            SudokuGame igame = new SudokuGame();
            igame.SetMaxValue(9);
            int actual = igame.maxValue;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetMaxValue_Test1()
        {
            //test GetMaxValue when maxValue equal 3
            int expected = 3;
            SudokuGame igame = new SudokuGame();
            igame.CSVArray = new int[1] { 3 };
            int actual = igame.GetMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxValue_Test2()
        {
            //test GetMaxValue when maxValue equal 6
            int expected = 6;
            SudokuGame igame = new SudokuGame();
            igame.CSVArray = new int[1] { 6 };
            int actual = igame.GetMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxValue_Test3()
        {
            //test GetMaxValue when maxValue equal 9
            int expected = 9;
            SudokuGame igame = new SudokuGame();
            igame.CSVArray = new int[1] { 9 };
            int actual = igame.GetMaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToArray()
        {
            
            string test = "1a2,3.4#5/6t7:8*9!_";
            SudokuGame igame = new SudokuGame();
            igame.CSVFile = test;
            igame.ToArray();

            for(int i=0; i < 9; i++)
            {
                Assert.AreEqual(i+1, igame.CSVArray[i]);
            }
        }

        [TestMethod]
        public void Set()
        {
            int[] testValues = new int[19] { 4, 2, 2, 9, 8, 7, 6, 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3 };

            SudokuGame igame = new SudokuGame();
            igame.SetMaxValue(4);
            igame.Set(testValues);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(9-i%9, igame.sudokuArray[i]);
            }
        }

        [TestMethod]
        public void GetSquareWidth()
        {
            //test with equal 2
            int expected = 3;
            SudokuGame igame = new SudokuGame();
            igame.CSVArray = new int[3] { 1, 2, 3 };
            int actual = igame.GetSquareWidth();
            Assert.AreEqual(expected, actual);
        }

                
        [TestMethod]
        public void SetSquareWidth1()
        {
            //test with equal 2
            int expected = 2;
            SudokuGame igame = new SudokuGame();
            igame.SetSquareWidth(2);
            int actual = igame.squareWidth;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetSquareWidth2()
        {
            //test with equal 3
            int expected = 3;
            SudokuGame igame = new SudokuGame();
            igame.SetSquareWidth(3);
            int actual = igame.squareWidth;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetSquareHeight1()
        {
            //test with equal 2
            int expected = 2;
            SudokuGame igame = new SudokuGame();
            igame.CSVArray = new int[3] { 1, 2, 3 };
            int actual = igame.GetSquareHeight();
            Assert.AreEqual(expected, actual);
        }

        

        [TestMethod]
        public void SetSquareHeight1()
        {
            //test with equal 2
            int expected = 2;
            SudokuGame igame = new SudokuGame();
            igame.SetSquareHeight(2);
            int actual = igame.squareHeight;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetSquareHeight2()
        {
            //test with equal 3
            int expected = 3;
            SudokuGame igame = new SudokuGame();
            igame.SetSquareHeight(3);
            int actual = igame.squareHeight;
            Assert.AreEqual(expected, actual); 
        }

        [TestMethod]
        public void Restart()
        {
            SudokuGame igame = new SudokuGame();
            
            igame.CSVFile = "123123456789123456789123456789";
            igame.SetMaxValue(4);
            igame.Restart();
            int actual = igame.sudokuArray[1];

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(i % 9 + 1, igame.sudokuArray[i]);
            }
        }
    }
}
