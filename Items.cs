using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesMachine
{
    abstract class Item
    {
        private readonly Int32 price;

        private readonly String name;

        public abstract String getName(Int32 count = 1);

        public Item(Int32 aPrice, String aName)
        {
            price = aPrice;
        }

        public Int32 Price
        {
            get
            {
                return price;
            }
        }
    }

    class Cake : Item
    {
        public const Int32 CakePrice = 50;

        public const String name = "Кекс";

        public Cake(): 
            base(CakePrice, name)
        { }

        public override string getName(Int32 count = 1)
        {
            if (count > 1)
                return "Кекса";
            return name;
        }
    }

    class Cookie : Item
    {
        public const Int32 CookiePrice = 10;

        public const String name = "Печенье";

        public Cookie(): 
            base(CookiePrice, name)
        { }

        public override string getName(Int32 count = 1)
        {
            if (count > 1)
                return "Печенья";
            return name;
        }
    }

    class Wafer : Item
    {
        public const Int32 WaferPrice = 30;

        public const String name = "Вафли";

        public Wafer()
            : base(WaferPrice, name)
        { }

        public override string getName(Int32 count = 1)
        {
            if (count > 4)
                return "Вафель";
            return name;
        }
    }
}
