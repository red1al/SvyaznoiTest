using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesMachine
{
    abstract class Coin
    {
        private readonly Int32 faceValue;

        public static String RoublesSuffix(Int32 count)
        {
            Int32 ending = count % 10;
            if (ending == 1)
                return "рубль";
            else if (ending > 1 && ending < 5)
                return "рубля";
            else
                return "рублей";
        }

        public static String CoinsName(Int32 count)
        {
            Int32 ending = count % 10;
            if (ending == 1)
                return "монета";
            else if (ending > 1 && ending < 5)
                return "монеты";
            else
                return "монет";
        }

        public Coin(Int32 aValue)
        {
            faceValue = aValue;
        }

        public Int32 Value
        {
            get
            {
                return faceValue;
            }
        }
    }

    class OneCoin : Coin
    {
        public const Int32 value = 1;

        public OneCoin() 
            : base(value)
        {

        }
    }

    class TwoCoin : Coin
    {
        public const Int32 value = 2;
        public TwoCoin() 
            : base(value)
        {

        }
    }

    class FiveCoin : Coin
    {
        public const Int32 value = 5;
        public FiveCoin()
            : base(value)
        {

        }
    }

    class TenCoin : Coin
    {
        public const Int32 value = 10;
        public TenCoin()
            : base(value)
        {

        }
    }
}
