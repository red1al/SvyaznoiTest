using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesMachine
{
    static class Customer
    {
        private static Int32 account = 150;

        public static Int32 Account
        {
            get
            {
                return account;
            }
        }

        public static void PutCoinInMachine(String aCoinValue)
        {
            Coin puttingCoin = null;
            switch (aCoinValue)
            {
                case "1":
                    puttingCoin = new OneCoin();
                    break;
                case "2":
                    puttingCoin = new TwoCoin();
                    break;
                case "5":
                    puttingCoin = new FiveCoin();
                    break;
                case "10":
                    puttingCoin = new TenCoin();
                    break;
            }
            if (puttingCoin.Value > account)
                throw new OutOfMoneyException();
            VendingMachine.AddCoin(puttingCoin);
            account -= puttingCoin.Value;
        }

        public static void OrderItem(String aMenuNumber)
        {
            switch (aMenuNumber)
            {
                case "1":
                    VendingMachine.MakeOrder(new Cake());
                    break;
                case "2":
                    VendingMachine.MakeOrder(new Cookie());
                    break;
                case "3":
                    VendingMachine.MakeOrder(new Wafer());
                    break;
            }
        }

        public static List<Coin> RequestRenting(out Boolean isEnoughCoinsForRent)
        {
            List<Coin> rentCoins = VendingMachine.GiveRenting(out isEnoughCoinsForRent);
            foreach (Coin c in rentCoins)
                account += c.Value;
            return rentCoins;
        }

        public static void LeaveMoney()
        {
            VendingMachine.HoldRenting();
        }
    }
}
