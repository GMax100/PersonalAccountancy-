using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    class ItemSet
    {
        protected string name;
        protected List<IFinancialPoint> items;
        protected TypeCurrency curr;

        public virtual string Name { get { return name; } }
        public virtual ItemView this[int i] { get { return items[i].GetView(); } }
        public virtual int GenSum { get; }
        public virtual TypeCurrency GenCurrency { get { return curr; } }

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
    }
}
