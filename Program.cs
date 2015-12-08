using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в торговый автомат");
            String input = "";
            while (!input.Equals("выход", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    Console.WriteLine("У вас " + Customer.Account + " " + Coin.RoublesSuffix(Customer.Account));
                    Console.WriteLine("Введите монеты по-одному, набирая '1', '2', '5' или '10'.'к заказу' для перехода далее");
                    while (!input.Equals("к заказу", StringComparison.InvariantCultureIgnoreCase))
                    {
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                            case "2":
                            case "5":
                            case "10":
                                Customer.PutCoinInMachine(input);
                                break;
                            case "к заказу":
                                break;
                            default:
                                Console.WriteLine("Неверный ввод!");
                                break;
                        }
                    }
                    Console.WriteLine("Возможные опции:");

                    Console.WriteLine("1. Кекс - " + Cake.CakePrice + " " + Coin.RoublesSuffix(Cake.CakePrice));
                    Console.WriteLine("2. Печенье - " + Cookie.CookiePrice + " " + Coin.RoublesSuffix(Cookie.CookiePrice));
                    Console.WriteLine("3. Вафли - " + Wafer.WaferPrice + " " + Coin.RoublesSuffix(Wafer.WaferPrice));
                    input = Console.ReadLine();
                    while (input != "1" && input != "2" && input != "3")
                    {
                        Console.WriteLine("Неверный ввод!");
                        input = Console.ReadLine();
                    }
                    try
                    {
                        Customer.OrderItem(input);
                    }
                    catch (OutOfItemsException)
                    {
                        Console.WriteLine("Этот пункт меню закончился");
                    }
                    catch (NotEnoughMoneyException)
                    {
                        Console.WriteLine("Вы внесли недостаточно денег");
                    }
                }
                catch (OutOfMoneyException)
                {
                    Console.WriteLine("У вас нет столько денег");
                }
                Console.WriteLine("Запросить ли сдачу?");
                Console.WriteLine("Введите 'да' для запроса сдачи, любой другой ввод - нет (внесенные деньги останутся в автомате!)");
                input = Console.ReadLine();

                if (input.Equals("да", StringComparison.InvariantCultureIgnoreCase))
                {
                    Boolean isEnoughCoinsForRent;
                    List<Coin> rentCoins = Customer.RequestRenting(out isEnoughCoinsForRent);

                    Int32 rent = 0;
                    foreach (Coin c in rentCoins)
                    {
                        rent += c.Value;
                    }

                    Console.WriteLine("Вам было возвращено: " + rent + " " + Coin.RoublesSuffix(rent));
                    foreach (Coin c in rentCoins)
                    {
                        Console.Write(c.Value + " ");
                    }
                    Console.WriteLine();
                    if (!isEnoughCoinsForRent)
                        Console.WriteLine("Потому что монет не хватило");
                }
                else
                {
                    Customer.LeaveMoney();
                }
                Console.WriteLine("Введите 'выход' для выхода, любой другой ввод - продолжить работу");
                input = Console.ReadLine();
            }
        }
    }
}
