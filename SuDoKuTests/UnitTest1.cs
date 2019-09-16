using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuDoKu;

namespace SuDoKuTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FromCSV_Test()
        {
            SudokuGame myGame= new SudokuGame();
            string CSVFile = "";
            CSVFile = "6,3,2" + '\n';
            CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');
            myGame.FromCSV(CSVFile);
            Assert.AreEqual(CSVFile, myGame.CSVFile);
        }

        [TestMethod]
        public void ToArray_Test()
        {

        }
    }
}
