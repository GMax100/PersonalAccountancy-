using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountingLibrary
{
    class RateTable
    {
        private TimeSpan actuality;
        private Dictionary<DateTime, Dictionary<TypeCurrency, double>> rates;

        public RateTable()
        {
            rates = new Dictionary<DateTime, Dictionary<TypeCurrency, double>>();
            actuality = new TimeSpan(TimeSpan.TicksPerDay);
        }

        public void Refresh()
        {
            if(!FindFresh(DateTime.Now))
                GetRatesNow();
        }

        public double Rate(DateTime date, TypeCurrency currency)
        {
            DateTime neerest = FindNeerestDate(date);
            return rates[date][currency];
        }

        private void GetRatesNow() // для того самого запроса курса
        {
            Dictionary<TypeCurrency, double> rates = new Dictionary<TypeCurrency, double>();

            rates.Add(TypeCurrency.Ruble, 1);
            // аналогично для TypeCurrency.Dollar и TypeCurrency.Euro, но с полученным откуда-то числом

            AddRates(DateTime.Now, rates);
        }

        private void AddRates(DateTime date, Dictionary<TypeCurrency, double> rates)
        {
            if(rates!=null && date!=null && date != DateTime.MinValue)
                this.rates.Add(date, rates);
        }

        private bool FindFresh(DateTime date)
        {
            TimeSpan t;
            FindNeerDate(date, out t);
            if (t < actuality)
                return true;
            return false;
        }

        private DateTime FindNeerestDate(DateTime date)
        {
            TimeSpan t;
            return FindNeerDate(date, out t);
        }

        private DateTime FindNeerDate(DateTime neededDate, out TimeSpan differ)
        {
            DateTime neerestDate = DateTime.MinValue;
            differ = neededDate - neerestDate;
            foreach (DateTime d in rates.Keys)
            {
                if (neededDate - d < differ)
                {
                    differ = neededDate - d;
                    neerestDate = d;
                }
            }
            return neerestDate;
        }
    }
}
