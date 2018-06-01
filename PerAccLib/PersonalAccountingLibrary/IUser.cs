using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    public interface IUser
    {
        string Name { get; }
        string OpenBudg { get; }
        string OpenItem { get; }

        List<string> ReadBudgs { get; }
        List<string> RedactBudgs { get; }

        List<List<ItemView>> OpenBudgItems { get; }
        List<string> this[int i] { get; }
        ItemView this[int i, int j] { get; }

        //bool ValidPassword(string password);
        void LoadBudget(string name);
        void OpenItemSet(int i);

        void AddBudget(string name);
        void AddSet(string name);
        void AddItem(int index, ItemView newItem);

        void RemoveBudget();
        void RemoveBudget(string name);
        void RemoveSet();
        void RemoveSet(int i);
        void RemoveItem(int i);
        void RemoveItem(int i, int set);
    }
}
