using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProvider
{
    delegate void Call(object sender, CallArgs args);
    class Provider
    {
        private event Call callPerson;
        ArrayList clients;

        public void Init()
        {
            this.clients = new ArrayList();
            PhoneCard a1 = new PhoneCard("Ion");
            Subscription a2 = new Subscription("Maria", SubscriptionType.One_Year);
            Subscription a3 = new Subscription("Popescu", SubscriptionType.Two_Years); 
            Subscription a4 = new Subscription("Ionescu", SubscriptionType.Three_Years);
            PhoneCard a5 = new PhoneCard("Marinescu");
            PhoneCard a6 = new PhoneCard("Marin");
            clients.Add(a1);
            clients.Add(a2);
            clients.Add(a3);
            clients.Add(a4);
            clients.Add(a5);
            clients.Add(a6);
            this.callPerson += CheckSubscription;
            this.callPerson += CallClient;
        }
        public PhoneAccount this[int index]
        {
            get
            {
                if (index < 0 || index >= clients.Count)
                {
                    return null;
                }
               
                return (PhoneAccount)this.clients[index];
            }
           
        }
        private void CheckSubscription(object sender, CallArgs args)
        {
            
            for (int i = 0; i < clients.Count; i++)
             {
                if (clients[i] is Subscription)
                {
                    Subscription a = (Subscription)clients[i];

                    if (a.CodAbonat == args.CodAbonat)
                    {
                        if (a.TotalAmount > 30)
                        {
                            clients.Remove(a);
                        }
                    }
                }else if(clients[i] is PhoneCard)
                {
                    PhoneCard a = (PhoneCard)clients[i];

                    if (a.CodAbonat == args.CodAbonat)
                    {
                        if (a.Amount > 30)
                        {
                            clients.Remove(a);
                        }
                    }
                }
             }
            
        }
        private void CallClient(object sender, CallArgs args)
        {

            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i] is Subscription)
                {


                    Subscription a = (Subscription)clients[i];
                    if (a.CodAbonat == args.CodAbonat)
                    {
                        a.MakeACall(args.Minutes);
                    }
                }
                else if (clients[i] is PhoneCard)
                {
                    PhoneCard a = (PhoneCard)clients[i];
                    if (a.CodAbonat == args.CodAbonat)
                    {
                        a.MakeACall(args.Minutes);
                    }
                }
            }
        }
        public void Apel(int codAbonat, int minutes)
        {
            CallArgs args = new CallArgs(codAbonat,minutes,0) ;
            this.callPerson(this, args);
        }
        public void List()
        {
            string mesaj = "";
            foreach (PhoneAccount a in clients)
            {
                if (a is Subscription)
                {
                    Subscription b = (Subscription)a;
                    mesaj = "Nume: " + b.Name + " Cod abonat: " + b.CodAbonat + " Suma totala de plata: " + b.TotalAmount;
                    Console.WriteLine(mesaj);
                    mesaj = "";
                }
                else
                {
                    PhoneCard b = (PhoneCard)a;
                    mesaj = "Nume: " + b.Name + " Cod abonat: " + b.CodAbonat + " Credit disponibil: " + b.Amount;
                    Console.WriteLine(mesaj);
                    mesaj = "";
                }

            }
        }
    }
}