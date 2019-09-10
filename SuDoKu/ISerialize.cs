using System;
using System.Collections.Generic;
using System.Text;

namespace SuDoKu
{
    interface ISerialize
    {
        void FromCSV(string csv);
        string ToCSV();
        void SetCell(int value, int gridIndex);
        int GetCell(int gridIndex);
        string ToPrettyString();
    }
}