using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Shop
{
    class Informer
    {
        Program pr = new Program();
        

        public void Buy(User user, Product product)
        {
            pr.connectionProp.Open();
            double price = product.GetDiscountPrice(user);
            user.ReduceBalance(price);
            Console.WriteLine($"{user.Name} купил {product.Name} за {price}.Заказ отправлен на склад");

            string sql1 = string.Format($"Insert into ShopUsersOrder (UserOrderId,OrderDate,Goods)" +
                $" values ({user.Id}, GETDATE(),'{product.Name}');");
            using (SqlCommand cmd = new SqlCommand(sql1, pr.connectionProp))
            {
                cmd.ExecuteNonQuery();
            }

            string sql2 = string.Format($"update ShopUsers set UserBalance = {user.Balance}, UserSpent = {user.Spent} where UserName = '{user.Name}';");
            using (SqlCommand cmd = new SqlCommand(sql2, pr.connectionProp))
            {
                cmd.ExecuteNonQuery();
            }
            pr.connectionProp.Close();
        }
    }
}
