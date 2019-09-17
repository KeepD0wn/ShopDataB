using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Tea:Product
    {
        public string Size { get; set; }

        public Tea(string name, int price, string manufacture, string size)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacture;
            Size = size;

            Console.WriteLine("Чай зелёный");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Цена: {Price}");
            Console.WriteLine($"Производитель: {Manufacturer}");
            Console.WriteLine($"Размер стакана: {Size}");
            Console.WriteLine(new String('-', 25));
        }

        public override double GetDiscountPrice(User user)
        {
            if (user.Name[0] == 'А')
            {
                return Price / 2;
            }
            else
            {
                return Price;
            }
        }
    }
}
