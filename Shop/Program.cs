using System;
using System.Data.SqlClient;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            void AddDat(out string log,out string passwor)
            {
                Console.WriteLine("Введите логин");
                log = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите пароль");
                passwor = Convert.ToString(Console.ReadLine());
            }

            SqlConnection connect = new SqlConnection("Server=desktop-rr78npp; Database=ShopDATA866; Trusted_Connection=true;");
            connect.Open();

            User nUser = new User(
                "",
                "",
                0,
                0
                );
            string login, password;
            AddDat(out login,out password);

            SqlCommand sql = new SqlCommand($"select * from ShopUsers where UserName = '{login}'", connect);
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                int viewed = 0;
                while (reader.Read())
                {
                    
                    viewed++;
                    if (password == reader[2].ToString())
                    {
                        Console.WriteLine("Заходим на сайт");
                        nUser = new User
                        (
                          reader[1].ToString(),
                          reader[3].ToString(),
                           Convert.ToDouble(reader[4]),
                           Convert.ToDouble(reader[5])
                        );
                    }
                    else
                    {
                        Console.WriteLine("Неправильно введённые данные");
                        return;
                    }
                }

                if (viewed == 0)
                {
                    Console.WriteLine("Нет пользователя с таким логином. Повторите ввод");
                    return;
                }

            }



            Console.WriteLine("\nСписок товаров");

            Bulki bulka = new Bulki(
                "Булка с изюмом",
                35,
                "OOO Бабушка",
                "Изюм"
                );

            Tea greenTea = new Tea(
                "Зелёный чай",
                5,
                "Сам сделяль",
                "200 мл"
                );

            Bread bread = new Bread(
            "Королевский хлеб",
            100,
            "Ларёк за углом",
            "Мука, дрожжи, специи"
                );

            Product[] product = new Product[]
            {
                bread,
                bulka,
                greenTea
            };

            Informer informer = new Informer();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Здравствуйте {nUser.Name} ваш баланс {nUser.Balance}");

                for (int i = 0; i < product.Length; i++)
                {
                    Console.WriteLine($"Товар {i}: {product[i].Name} по цене {product[i].Price}");
                }
                Console.WriteLine("Выберите номер товара: ");

                string str = Console.ReadLine();

                int ProductNumber = Convert.ToInt32(str);

                if (ProductNumber >= 0 && ProductNumber < product.Length)
                {
                    if (product[ProductNumber].Price <= nUser.Balance)
                    {
                        informer.Buy(nUser, product[ProductNumber]);
                        string sql1 = string.Format($"update ShopUsers set UserBalance = {nUser.Balance}, UserSpent = {nUser.Spent} where UserName = '{login}';");
                        using (SqlCommand cmd = new SqlCommand(sql1, connect))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }
                }

                else
                {
                    Console.WriteLine("Таких товаров нет");
                }

            }
        }
    }
    
}
