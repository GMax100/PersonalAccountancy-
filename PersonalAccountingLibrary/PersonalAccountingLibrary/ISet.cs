using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    interface ISet
    {
        string Name { get; }
        ItemView this[int i] { get; }
        int GenSum { get; }
        TypeCurrency GenCurrency { get; }

        void ChangeItem(int index, ItemView newItem);
    }
}
