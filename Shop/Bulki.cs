using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Bulki:Product
    {
        public string Material { get; set; }

        public Bulki(string name, int price, string manufacture, string material)
        {
            Name = name;
            Price = price;
            Manufacturer = manufacture;
            Material = material;

            Console.WriteLine("Булка");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Цена: {Price}");
            Console.WriteLine($"Производитель: {Manufacturer}");
            Console.WriteLine($"Материал начинки: {Material}");
            Console.WriteLine(new String('-', 25));
        }
    }
}
