using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    public class User : IUser
    {
        protected string name;
        //protected string password;
        //protected string realPassword;
        protected bool mona;
        private List<Budget> myBudg;
        private List<Budget> readBudg;
        private Budget select;
        private ItemSet open;

        

        public string Name { get { return name; } }
        public string OpenBudg { get { if (select == null) return null; return select.Name; } }
        public string OpenItem { get { if (open == null) return null; return open.Name; } }

        public List<string> ReadBudgs { get { return CollectRead(); } }
        public List<string> RedactBudgs { get { return CollectRedact(); } }

        public List<List<ItemView>> OpenBudgItems { get; }
        public List<string> this[int i] { get { return CollectSets() ; } }
        public ItemView this[int i, int j] { get { return select[i][j]; } }

        public User()
        {
            name = "";
            //password = realPassword = "";
            myBudg = new List<Budget>();
            readBudg = new List<Budget>();
            mona = false;
        }

        public User(string name)
        {
            this.name = name;
            //password = realPassword = "";
            myBudg = new List<Budget>();
            readBudg = new List<Budget>();
            mona = false;
        }

        public void LoadBudget(string name)
        {
            if (!RedactBudgs.Contains(name) && !ReadBudgs.Contains(name))
                AddBudget(name);
            select = FindBudg(name);
        }

        private Budget FindBudg(string name)
        {
            if(ReadBudgs.Contains(name))
            {
                for (int i = myBudg.Count - 1; i >= 0; i++)
                    if (myBudg[i].Name == name)
                        return myBudg[i];
            }

            if (RedactBudgs.Contains(name))
            {
                for (int i = readBudg.Count - 1; i >= 0; i++)
                    if (readBudg[i].Name == name)
                        return readBudg[i];
            }

            return null;
        }

        //public bool ValidPassword(string password)
        //{
        //    if (this.password == realPassword)
        //    {
        //        this.password = password;
        //        return true;
        //    }
        //    return false;
        //}

        public void OpenItemSet(int i)
        {
            if (select == null)
                return;
            open = select[i];
        }

        protected List<string> CollectRedact()
        {
            List<string> my = new List<string>();

            for (int i = 0; i < myBudg.Count; i++)
            {
                my.Add(myBudg[i].Name);
            }

            return my;
        }

        protected List<string> CollectRead()
        {
            List<string> read = new List<string>();

            for (int i = 0; i < readBudg.Count; i++)
            {
                read.Add(readBudg[i].Name);
            }

            return read;

        }

        protected List<string> CollectSets()
        {
            List<string> sets = new List<string>();

            if (select == null)
                return sets;
            for (int i = 0; i < select.Count; i++)
            {
                sets.Add(select[i].Name);
            }

            return sets;
        }

        public void AddBudget(string name)
        {
            myBudg.Add(new Budget(name));
        }

        public void AddSet(string name)
        {
            if (select == null)
                return;
            select.AddSet(name);
        }

        public void AddItem(int index, ItemView newItem)
        {
            if (select == null || index<0||index>=select.Count)
                return;
            select[index].AddItem(newItem);
        }

        public void RemoveBudget()
        {
            if (myBudg.Contains(select))
            {
                myBudg.Remove(select);
                select = null;
                return;
            }

            if (readBudg.Contains(select))
            {
                readBudg.Remove(select);
                select = null;
            }

        }

        public void RemoveBudget(string name)
        {
            if (select == null)
                return;

            Budget b = FindBudg(name);
            if (b == null)
                return;

            myBudg.Remove(b);
            readBudg.Remove(b);
        }

        public void RemoveSet()
        {
            if (select == null||open == null)
                return;
            select.RemoveSet(open.Name);
        }

        public void RemoveSet(int i)
        {
            if (select == null)
                return;
            select.RemoveSet(open.Name);

        }

        public void RemoveItem(int i)
        {
            if (select == null || open == null)
                return;
            open.RemoveItem(i);
        }
        
        public void RemoveItem(int i, int set)
        {
            if (select == null)
                return;

            select[set].RemoveItem(i);
        }
        
    }
}
