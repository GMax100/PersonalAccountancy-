using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    class ItemSet : ISet
    {
        protected string name;
        protected List<IFinancialPoint> items;
        protected TypeCurrency curr;

        public virtual string Name { get { return name; } }
        public virtual int GenSum { get; }
        public virtual TypeCurrency GenCurrency { get { return curr; } }

        public virtual ItemView this[int i] { get { return items[i].GetView(); } }
        public virtual List<ItemView> Items { get { return ListOfView(); } }

        public ItemSet(string name, TypeCurrency curr)
        {
            this.name = name;
            this.curr = curr;
            items = new List<IFinancialPoint>();
        }

        public virtual void ChangeItem(int index, ItemView newItem)
        {
            if (newItem.Name != items[index].Name)
                items[index].ChangeName(newItem.Name);
            if (newItem.Sum != items[index].Value)
                items[index].ChangeValue(newItem.Sum);
            if (newItem.Date != items[index].When)
                items[index].ChangeDate(newItem.Date);
            if (newItem.Currency != items[index].Currency)
                items[index].ChangeCurrency(newItem.Currency);
            if (newItem.Type != items[index].Ment)
                items[index].ChangeItem(newItem.Type);
        }

        protected virtual List<ItemView> ListOfView()
        {
            List<ItemView> itms = new List<ItemView>();

            for (int i = 0; i < items.Count; i++)
                itms.Add(items[i].GetView());

            return itms;
        }


        public void AddItem(ItemView newItem)
        {
            items.Add(new Item(newItem.Name, newItem.Sum, newItem.Type, newItem.Date, newItem.Currency));
        }

        public void RemoveItem(int index)
        {
            items.Remove(items[index]);
        }
    }
}
