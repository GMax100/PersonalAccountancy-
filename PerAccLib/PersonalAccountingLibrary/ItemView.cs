using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    public struct ItemView
    {
        private string name;
        private decimal sum;
        private DateTime date;
        private TypeCurrency curr;
        private TypeItem type;

        public string Name { get { return name; } }
        public decimal Sum { get { return sum; } }
        public DateTime Date { get { return date; } }
        public TypeCurrency Currency { get { return curr; } }
        public TypeItem Type { get { return type; } }

        public ItemView(string name, decimal sum, DateTime date, TypeCurrency curr, TypeItem type)
        {
            this.name = name;
            this.sum = sum;
            this.date = date;
            this.curr = curr;
            this.type = type;
        }

        public ItemView(IFinancialPoint fp)
        {
            name = fp.Name;
            sum = fp.Value;
            date = fp.When;
            curr = fp.Currency;
            type = fp.Ment;
        }
    }
}
