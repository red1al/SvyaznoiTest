using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesMachine
{
    class OutOfMoneyException : Exception
    {
    }

    class OutOfItemsException : Exception
    {
    }

    class NotEnoughMoneyException : Exception
    {
    }
}
