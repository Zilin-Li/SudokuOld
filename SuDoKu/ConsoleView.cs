using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuDoKu
{
    class ConsoleView : IView
    {
        public int[] GetCellChangeData(string prompt)
        {
            Console.WriteLine(prompt);
            string readString = Console.ReadLine();
            int[] dataSplit = readString.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            return dataSplit;
        }

        public void DisplayBoard(string boardAsString)
        {
            Console.WriteLine(boardAsString);
        }
        public void Clear()
        {
            Console.Clear();
        }
        public void Finish()
        {
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
        }

    }
}
