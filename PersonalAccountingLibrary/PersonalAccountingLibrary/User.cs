using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    class User : IUser
    {
        protected string name;

        public string Name { get { return name; } }

        public bool ValidPassword(string password)
        {
            return true;
        }
    }
}
