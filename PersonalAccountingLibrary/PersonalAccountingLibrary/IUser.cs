using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    interface IUser
    {
        string Name { get; }

        bool validPassword(string password);

        List<IBudget> readerBudgets(string password);
    }
}
