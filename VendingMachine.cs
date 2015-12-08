using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesMachine
{
    static class VendingMachine
    {
        private const Int32 cakesStartCount = 4;
        private const Int32 cookiesStartCount = 3;
        private const Int32 wafersStartCount = 10;

        private static Int32 currentDeposit = 0;

        private static Stack<OneCoin> oneCoins = new Stack<OneCoin>();
        private static Stack<TwoCoin> twoCoins = new Stack<TwoCoin>();
        private static Stack<FiveCoin> fiveCoins = new Stack<FiveCoin>();
        private static Stack<TenCoin> tenCoins = new Stack<TenCoin>();

        private static Stack<Cake> cakes = new Stack<Cake>(cakesStartCount);
        private static Stack<Cookie> cookies = new Stack<Cookie>(cookiesStartCount);
        private static Stack<Wafer> wafers = new Stack<Wafer>(wafersStartCount);

        static VendingMachine()
        {
            for (int i = 0; i < cakesStartCount; i++)
                cakes.Push(new Cake());
            for (int i = 0; i < cookiesStartCount; i++)
                cookies.Push(new Cookie());
            for (int i = 0; i < wafersStartCount; i++)
                wafers.Push(new Wafer());
        }

        public static void AddCoin(Coin aCoin)
        {
            currentDeposit += aCoin.Value;
            if (aCoin is OneCoin)
                oneCoins.Push((OneCoin)aCoin);
            else if (aCoin is TwoCoin)
                twoCoins.Push((TwoCoin)aCoin);
            else if (aCoin is FiveCoin)
                fiveCoins.Push((FiveCoin)aCoin);
            else
                tenCoins.Push((TenCoin)aCoin);
        }

        public static void MakeOrder(Item aItem)
        {
            if (currentDeposit < aItem.Price)
                throw new NotEnoughMoneyException();
            if (aItem.getName() == Cake.name)
            {
                if (cakes.Count == 0)
                    throw new OutOfItemsException();
                cakes.Pop();
            }
            else if (aItem.getName() == Cookie.name)
            {
                if (cookies.Count == 0)
                    throw new OutOfItemsException();
                cookies.Pop();
            }
            else
            {
                if (wafers.Count == 0)
                    throw new OutOfItemsException();
                wafers.Pop();
            }
            currentDeposit -= aItem.Price;
        }

        /* Вообще говоря, для задачи о сдаче жадный алгоритм не всегда будет
         * давать оптимальное решение. Однако при таком наборе монет (1, 2, 5 и 10)
         * он решает задачу оптимально. 
         */
        public static List<Coin> GiveRenting(out Boolean IsEnoughCoinsForRent)
        {
            List<Coin> result = new List<Coin>();
            while (currentDeposit >= TenCoin.value && tenCoins.Count() > 0)
            {
                result.Add(tenCoins.Pop());
                currentDeposit -= TenCoin.value;
            }
            while (currentDeposit >= FiveCoin.value && fiveCoins.Count() > 0)
            {
                result.Add(fiveCoins.Pop());
                currentDeposit -= FiveCoin.value;
            }
            while (currentDeposit >= TwoCoin.value && twoCoins.Count() > 0)
            {
                result.Add(twoCoins.Pop());
                currentDeposit -= TwoCoin.value;
            }
            while (currentDeposit >= OneCoin.value && oneCoins.Count() > 0)
            {
                result.Add(oneCoins.Pop());
                currentDeposit -= OneCoin.value;
            }
            Int32 rent = result.Sum(t => t.Value);
            IsEnoughCoinsForRent = (currentDeposit == 0);
            return result;
        }

        public static void HoldRenting()
        {
            currentDeposit = 0;
        }
    }
}
