using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    class Budget : IBudget
    {
        private string name;
        protected User owner;
        private TypeCurrency mainCurr;
        private List<ISet> items;

        public User Owner { get { return owner;} }
        public string Name { get { return name; } }
        public int Count { get { return items.Count; } }
        public string MainCurrency { get { return mainCurr.ToString(); } }

        public ItemSet this[int i] {
            get { return items[i] as ItemSet; }
        }
        public List<ItemView> this[string i] {
            get { return GetViewSet(i); }
        }
        public ItemView this[int i, int j] {
            get { return items[i][j]; }
            set { items[i].ChangeItem(j, value); }
        }

        public Budget(string name)
        {
            items = new List<ISet>();
            mainCurr = TypeCurrency.Ruble;
            this.name = name;
        }

        public Budget(string name, TypeCurrency curr)
        {
            items = new List<ISet>();
            mainCurr = curr;
            this.name = name;
        }

        protected virtual ISet FindSet(string name)
        {
            foreach (ISet i in items)
                if (i.Name == name)
                    return i;
            return null;
        }

        protected virtual List<ItemView> GetViewSet (string name)
        {
            ISet itm = FindSet(name);
            if (itm != null)
                return itm.Items;
            return new List<ItemView>();
        }

        public virtual void AddSet(string name)
        {
            ItemSet set = new ItemSet(name, mainCurr);
            items.Add(set);
        }

        public virtual void RemoveSet(string name)
        {
            ISet set = FindSet(name);
            if (set != null)
                items.Remove(set);
        }

        public virtual void RemoveSet(int index)
        {
            items.Remove(items[index]);
        }

        public virtual void RemoveAllSet(string name)
        {
            ISet set = FindSet(name);
            while (set != null)
            {
                items.Remove(set);
                set = FindSet(name);
            }
        }
    }
}
