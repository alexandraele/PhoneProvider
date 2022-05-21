using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProvider
{
    class Subscription : PhoneAccount, IDisposable
    {
        private int lastPayesMonth;
        private decimal totalAmount;
        private SubscriptionType type;
        public decimal TotalAmount { get { return this.totalAmount; } }

        public Subscription(string name,SubscriptionType type) : base(name)
        {
            this.type = type;
            this.lastPayesMonth = 7;
        }
        public void MakeACall(int nrMinute)
        {
            if (this.lastPayesMonth == 7)
            {
                switch (this.type)
                {
                    case SubscriptionType.One_Year: {
                            this.totalAmount += (decimal)0.12 * nrMinute;
                            break; }
                    case SubscriptionType.Two_Years:
                        {
                            this.totalAmount += (decimal)0.10 * nrMinute;
                            break;
                        }
                    case SubscriptionType.Three_Years:
                        {
                            this.totalAmount += (decimal)0.08 * nrMinute;
                            break;
                        }
                }
            }
            string info = "Suma: " + this.totalAmount + " lei " + "Tip abonament: " + this.type + "\n";
            this.Info(ref info);
        }
        public override void Info(ref string info)
        {
            base.Info(ref info);
            info += info;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
