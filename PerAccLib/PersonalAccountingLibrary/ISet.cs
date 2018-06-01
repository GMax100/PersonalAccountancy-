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
        int GenSum { get; }
        TypeCurrency GenCurrency { get; }

        List<ItemView> Items { get; }
        ItemView this[int i] { get; }

        void ChangeItem(int index, ItemView newItem);
        void AddItem(ItemView newItem);
        void RemoveItem(int index);
    }
}
