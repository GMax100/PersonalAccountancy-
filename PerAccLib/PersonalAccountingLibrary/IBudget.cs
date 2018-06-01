using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    interface IBudget
    {
        User Owner { get; }
        string Name { get; }
        string MainCurrency { get; }
        int Count { get; }

        ItemSet this[int i] { get; }
        List<ItemView> this[string i] { get ; }
        ItemView this[int i, int j] { get; set; }

        void AddSet(string name);
        void RemoveSet(string name);
        void RemoveSet(int index);
        void RemoveAllSet(string name);
    }
}
