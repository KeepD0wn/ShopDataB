using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    class Product
    {

        public double Price { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }

        public virtual double GetDiscountPrice(User user)
        {
            if (user.Spent > 300 && user.Spent < 1000)
            {
                return Price * 0.9;
            }

            if (user.Spent >= 1000)
            {
                return 0.8 * Price;
            }

            return Price;
        }
    }
}
