using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    interface IFinancialPoint
    {
        string Name { get; }
        decimal Value { get; }
        DateTime When { get; }
        TypeCurrency Currency { get; }
        TypeItem Aim { get; }

        void ChangeName(string newName);
        void ChangeValueOn(decimal odd);
        void ChangeValue(decimal newValue);
    }
}
