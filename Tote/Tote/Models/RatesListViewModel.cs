using System;
using System.Collections;

namespace Tote.Models
{
    public class RatesListViewModel:IEnumerable
    {
        public RateListViewModel[] ratesList;

        public int Length
        {
            get { return ratesList.Length; }
        }

        public RateListViewModel this[int index]
        {
            get
            {
                return ratesList[index];
            }
            set
            {
                ratesList[index] = value;
            }
        }

        // возвращаем перечислитель
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ratesList.GetEnumerator();
        }
    }
}