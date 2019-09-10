using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
    interface IView
    {
        int[] GetCellChangeData(string prompt);
        void DisplayBoard(string boardAsString);
        void Clear();
        void Finish();
    }
}
