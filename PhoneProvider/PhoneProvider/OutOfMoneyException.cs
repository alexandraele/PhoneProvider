using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProvider
{
    class OutOfMoneyException:Exception
    {
        public void OutOfMemoryException(decimal amount)
        {
            Console.WriteLine("Credit insuficient pentru a initia un apel.");
        }
    }
}