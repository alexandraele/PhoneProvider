using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            Provider p = new Provider();
            p.Init();
            int minute= 0;
            int cod= 0;
            int optiune = 0;
            while (true)
            {

                Console.WriteLine("1.Listeaza\n2.Realizeaza un apel\n3.Iesire");
                Console.WriteLine("optiune: ");
                optiune = int.Parse(Console.ReadLine());
                switch (optiune)
                {
                    case 1:
                        {
                            p.List();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Cod abonat:");
                            cod = int.Parse(Console.ReadLine());
                            Console.WriteLine("Minute:");
                            minute = int.Parse(Console.ReadLine());
                            p.Apel(cod,minute);
                            break;
                        }
                    case 3: { return; }
                }
            }
        }
    }
}

