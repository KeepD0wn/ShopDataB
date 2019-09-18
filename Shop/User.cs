using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class User
    {
        public string Name { get; set; }
        public string Adress { get; private set; }
        public double Balance { get; private set; }
        public double Spent { get; private set; }
        public int Id { get; set; }

        public User(string name, string adress, double balance, double spent,int id)
        {
            Name = name;
            Adress = adress;
            Balance = balance;
            Spent = spent;
            Id = id;
        }

        public void ReduceBalance(double price)
        {
            Balance -= price;
            Spent += price;
        }
    }
}
