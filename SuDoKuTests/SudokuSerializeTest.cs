using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuDoKu;

namespace SuDoKuTests
{
    [TestClass]
    public class SudokuSerializeTest
    {
        [TestMethod]
        public void FromCSV_Test()
        {
            SudokuGame igame= new SudokuGame();
            string CSVFile = "";
            CSVFile = "6,3,2" + '\n';
            CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');
            igame.FromCSV(CSVFile);
            Assert.AreEqual(CSVFile, igame.CSVFile);
        }

        [TestMethod]
        public void ToCSV_Test()
        {
            string expected = "1,2,3,4,5,6,7,8,9,\n";
            SudokuGame igame = new SudokuGame();
            igame.sudokuArray = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string actual = igame.ToCSV();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCell_Test1()
        {
            // test 4*4, cell3
            int expected = 1;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[4 * 4];
            igame.SetCell(1, 3);
            int actual = igame.sudokuArray[3];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCell_Test2()
        {
            // test 4*4, cell 0
            int expected = 4;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[4 * 4];
            igame.SetCell(4, 0);
            int actual = igame.sudokuArray[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCell_Test3()
        {
            // test 4*4, cell 15
            int expected = 4;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[4 * 4];
            igame.SetCell(4, 15);
            int actual = igame.sudokuArray[15];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCell_Test4()
        {
            // test 9*9, cell 80
            int expected = 9;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.sudokuArray = new int[9 * 9];
            igame.SetCell(9, 80);
            int actual = igame.sudokuArray[80];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetCell_Test5()
        {
            // test 9*9, cell 0
            int expected = 8;
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.sudokuArray = new int[9 * 9];
            igame.SetCell(8, 0);
            int actual = igame.sudokuArray[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCell_Test1()
        {
            // test 4*4, get GetCell
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.sudokuArray = new int[4 * 4];

            for(int i=0; i < 16; i++)
            {
                igame.sudokuArray[i] = i;
            }

            for (int i = 0; i < 16; i++)
            {
                int actual = igame.GetCell(i);
                Assert.AreEqual(i, actual);
            }
        }

        [TestMethod]
        public void GetCell_Test2()
        {
            // test 6*6, get GetCell
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.sudokuArray = new int[6 * 6];

            for (int i = 0; i < 36; i++)
            {
                igame.sudokuArray[i] = i;
            }

            for (int i = 0; i < 36; i++)
            {
                int actual = igame.GetCell(i);
                Assert.AreEqual(i, actual);
            }
        }

        [TestMethod]
        public void GetCell_Test3()
        {
            // test 6*6, get GetCell
            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.sudokuArray = new int[9 * 9];

            for (int i = 0; i < 81; i++)
            {
                igame.sudokuArray[i] = i;
            }

            for (int i = 0; i < 81; i++)
            {
                int actual = igame.GetCell(i);
                Assert.AreEqual(i, actual);
            }
        }

        [TestMethod]
        public void ToPrettyString1()
        {
            // test 4*4, get GetCell
            string expected = " 1 * | 3 4\n";
            expected += " 2 3 | * 1\n";
            expected += "-----+-----\n";
            expected += " * 4 | 1 2\n";
            expected += " * 1 | 2 *\n";

            SudokuGame igame = new SudokuGame();
            igame.maxValue = 4;
            igame.squareHeight = 2;
            igame.squareWidth = 2;
            igame.sudokuArray = new int[4 * 4] { 1,0,3,4,2,3,0,1,0,4,1,2,0,1,2,0};

            string actual = igame.ToPrettyString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPrettyString2()
        {
            // test 6*6, get GetCell, 3 high by 2 wide
            string expected = " * * | 3 4 | 5 6\n";
            expected += " * 3 | 4 5 | 6 1\n";
            expected += " * 4 | 5 6 | 1 2\n";
            expected += "-----+-----+-----\n";
            expected += " * 5 | 6 1 | 2 3\n";
            expected += " 5 * | 1 2 | 3 4\n";
            expected += " 6 1 | 2 3 | * *\n";

            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.squareHeight = 3;
            igame.squareWidth = 2;
            igame.sudokuArray = new int[6 * 6] { 0, 0, 3, 4, 5, 6, 0, 3, 4, 5, 6, 1, 0, 4, 5, 6, 1, 2, 0, 5, 6, 1, 2, 3, 5, 0, 1, 2, 3, 4, 6, 1, 2, 3, 0, 0 };

            string actual = igame.ToPrettyString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPrettyString3()
        {
            // test 6*6, get GetCell, 2 high by 3 wide
            string expected = " * * 3 | 4 5 6\n";
            expected += " * 3 4 | 5 6 1\n";
            expected += "-------+-------\n";
            expected += " * 4 5 | 6 1 2\n";
            expected += " * 5 6 | 1 2 3\n";
            expected += "-------+-------\n";
            expected += " 5 * 1 | 2 3 4\n";
            expected += " 6 1 2 | 3 * *\n";

            SudokuGame igame = new SudokuGame();
            igame.maxValue = 6;
            igame.squareHeight = 2;
            igame.squareWidth = 3;
            igame.sudokuArray = new int[6 * 6] { 0, 0, 3, 4, 5, 6, 0, 3, 4, 5, 6, 1, 0, 4, 5, 6, 1, 2, 0, 5, 6, 1, 2, 3, 5, 0, 1, 2, 3, 4, 6, 1, 2, 3, 0, 0 };

            string actual = igame.ToPrettyString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToPrettyString4()
        {
            // test 9*9, get GetCell, 3 high by 3 wide
            string expected = " 1 2 3 | 4 5 6 | 7 8 9\n";
            expected += " 2 3 4 | 5 6 7 | 8 9 1\n";
            expected += " 3 4 5 | 6 7 8 | 9 1 2\n";
            expected += "-------+-------+-------\n";
            expected += " 4 5 6 | 7 8 9 | 1 2 3\n";
            expected += " 5 6 7 | 8 9 1 | 2 3 4\n";
            expected += " 6 7 8 | 9 1 2 | 3 4 5\n";
            expected += "-------+-------+-------\n";
            expected += " 7 8 9 | 1 2 3 | 4 5 6\n";
            expected += " 8 9 1 | 2 3 4 | 5 6 7\n";
            expected += " 9 1 2 | 3 4 5 | 6 7 8\n";

            SudokuGame igame = new SudokuGame();
            igame.maxValue = 9;
            igame.squareHeight = 3;
            igame.squareWidth = 3;
            igame.sudokuArray = new int[9 * 9] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 1, 3, 4, 5, 6, 7, 8, 9, 1, 2, 4, 5, 6, 7, 8, 9, 1, 2, 3, 5, 6, 7, 8, 9, 1, 2, 3, 4, 6, 7, 8, 9, 1, 2, 3, 4, 5, 7, 8, 9, 1, 2, 3, 4, 5, 6, 8, 9, 1, 2, 3, 4, 5, 6, 7, 9, 1, 2, 3, 4, 5, 6, 7, 8 };

            string actual = igame.ToPrettyString();
            Assert.AreEqual(expected, actual);
        }


    }
}
