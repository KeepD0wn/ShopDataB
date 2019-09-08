using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Bread:Product
    {
        public string Composition { get; set; }

        public Bread(string name, int price, string manufacture, string composition)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacture;
            Composition = composition;

            Console.WriteLine("Хлеб");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Цена: {Price}");
            Console.WriteLine($"Производитель: {Manufacturer}");
            Console.WriteLine($"Состав: {Composition}");
            Console.WriteLine(new String('-', 25));
        }
    }
}
