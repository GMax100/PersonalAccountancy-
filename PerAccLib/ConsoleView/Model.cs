using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalAccountingLibrary;

namespace ConsoleView
{
    class Model
    {
        private User user;
        //private string password;
        private Random r;

        public User U { get { return user; } }

        public Model()
        {
            user = new User("Bendzhamen");
            r = new Random();
            RandomBudgs();
        }

        //public void LoadBudget(int ID_Budget)
        //{

        //}

        public void RandomBudgs()
        {
            user.LoadBudget("Main_Budget");
        }
        
    }
}
