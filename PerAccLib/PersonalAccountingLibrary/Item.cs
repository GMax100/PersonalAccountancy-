using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    class Item : IFinancialPoint
    {
        protected string name;
        protected decimal val; // финансовое значение - положительное и, по сути, в рублях
        protected DateTime date; // дата, в которую произошло
        protected TypeCurrency curr; // валюта для отображения в общем списке 
        protected TypeItem type; // тип - приход, уход, накопление

        public string Name { get { return name; } }
        public decimal Value { get { return val; } }
        public DateTime When { get { return date; } }
        public TypeCurrency Currency { get { return curr; } }
        public TypeItem Ment { get { return type; } }

        public Item()
        {
            name = "";
            val = 0;
            date = DateTime.Now;
            curr = TypeCurrency.Ruble;
            type = TypeItem.None;
        }

        public Item(string name, decimal value) // имя и значение (по умолчанию в рублях)
        {
            this.name = name;
            date = DateTime.Now;
            curr = TypeCurrency.Ruble;
            type = Math.Sign(value) > 0 ? TypeItem.Income : TypeItem.Outcome;

            if (value == 0)
            {
                val = 0;
                type = TypeItem.None;
            }
            else
                val = Math.Abs(value);
        }

        public Item(string name, decimal value, TypeItem type) // имя, значение (в рублях) и тип
        {
            this.name = name;
            val = Math.Abs(value);
            date = DateTime.Now;
            curr = TypeCurrency.Ruble;
            this.type = type;
        }

        public Item(string name, decimal value, TypeItem type, DateTime date)
        {
            this.name = name;
            val = Math.Abs(value);
            this.date = date;
            curr = TypeCurrency.Ruble;
            this.type = type;
        }

        public Item(string name, decimal value, TypeItem type, DateTime date, TypeCurrency currency) // обращение в RateTable ?!
        {
            this.name = name;
            val = Math.Abs(value);
            this.date = date;
            curr = currency;
            this.type = type;
        }

        public virtual void ChangeName(string newName)
        {
            name = newName;
        }

        public virtual void ChangeValueOn(decimal odd)
        {
            val += odd;
        }

        public virtual void ChangeValue(decimal newValue)
        {
            val = newValue;
        }

        public virtual void ChangeDate(DateTime newDate)
        {
            date = newDate;
        }

        public virtual void ChangeCurrency(TypeCurrency newCurrency)
        {
            curr = newCurrency;
        }

        public virtual void ChangeItem(TypeItem newType)
        {
            type = newType;
        }

        public ItemView GetView()
        {
            return new ItemView(this);
        }
    }
}
