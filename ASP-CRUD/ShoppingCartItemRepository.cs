using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using ASP_CRUD.Models;

namespace ASP_CRUD
{
    public class ShoppingCartItemRepository
    {
        public static string connectionString { get; set; }

        public static List<ShoppingCartItemModel> GetShoppingCartItems()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                return conn.Query<ShoppingCartItemModel>("SELECT ShoppingCartItemID,ShoppingCartID,Quantity,ProductID,DateCreated,ModifiedDate FROM shoppingcartitem;").ToList();
            }
        }

        public static void CreateShoppingCartItem(ShoppingCartItemModel cartItem)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                

                conn.Execute("INSERT INTO shoppingcartitem (ShoppingCartID,Quantity,ProductID,DateCreated) " +
                             "VALUES (@ShoppingCartID,@Quantity,@ProductID,@DateCreated)", 
                             new { ShoppingCartID = cartItem.ShoppingCartID, Quantity = cartItem.Quantity,
                                   ProductID = cartItem.ProductID, DateCreated = DateTime.Now });
            }
        }

        public static void UpdateShoppingCartItem(ShoppingCartItemModel cartItem)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute("UPDATE shoppingcartitem SET ShoppingCartID = @ShoppingCartID, Quantity = @Quantity, " +
                                  "ProductID = @ProductID,ModifiedDate =  @modifiedate " +
                                  "WHERE ShoppingCartItemID = @ShoppingCartItemID", 
                                  new {
                                        ShoppingCartID = cartItem.ShoppingCartID,
                                        Quantity = cartItem.Quantity, ProductID = cartItem.ProductID,
                                        @modifiedate = DateTime.Now,
                                        cartItem.ShoppingCartItemID
                                  });
            }
        }

        public static void DeleteShoppingCartItem(int shoppingCartItemID)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute("DELETE FROM shoppingcartitem WHERE ShoppingCartItemID = @ShoppingCartItemID;", new { ShoppingCartItemID = shoppingCartItemID });
            }
        }
    }
}