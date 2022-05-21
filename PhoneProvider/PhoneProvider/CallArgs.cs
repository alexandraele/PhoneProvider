using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProvider
{
    class CallArgs:EventArgs
    {
        private int codAbonat;
        private int minutes;
        private decimal amount;
        public int CodAbonat { get { return this.codAbonat; } }
        public int Minutes { get { return this.minutes; } }
        public decimal Amount { get { return this.amount; } }
        public CallArgs(int codAbonat,int minutes,int amount)
        {
            this.codAbonat = codAbonat;
            this.minutes = minutes;
            this.amount = amount;

        }
    }
}
