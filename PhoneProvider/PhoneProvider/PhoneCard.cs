using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProvider
{
    class PhoneCard:PhoneAccount
    {
        private decimal amount;
        public decimal Amount { get { return this.amount; } }

        public PhoneCard(string name) : base(name)
        {
            this.amount = 5;

        }
        public override void Info(ref string info)
        {
            base.Info(ref info);
            info += info;
        }
        public void MakeACall(int nrMinute)
        {
            try
            {
                decimal a = this.Amount;
                int nrMinuteDeUtilizat = (int)((double)a / 0.14);
                if (nrMinuteDeUtilizat >= nrMinute)
                {
                    this.amount = a - (decimal)(nrMinute * 0.14);
                    string mesaj = "Credit disponibil:" + this.Amount + "; numar de minute disponibile: " + (nrMinuteDeUtilizat -nrMinute) + " minute\n";
                    this.Info(ref mesaj);

                }
                else
                {
                    this.amount = a - (decimal)(nrMinuteDeUtilizat * 0.14);
                    string mesaj = "Credit disponibil:" + this.Amount + "; numar de minute disponibile: " + nrMinuteDeUtilizat + " minute\n";
                    this.Info(ref mesaj);
                }

                if (a < (decimal)(0.14 * 1))
                {
                    throw new OutOfMoneyException();
                }
            }catch(OutOfMoneyException e)
            {
                e.OutOfMemoryException(this.Amount);
            }
        }
    }
}
