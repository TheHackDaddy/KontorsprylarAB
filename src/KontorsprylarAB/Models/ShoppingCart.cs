using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace KontorsprylarAB.Models
{

    public class ShoppingCart
    {
        private int nextId = 1;
        public int Id { get; set; }

        public List<ShoppingItem> ShoppingList { get; set; }

        public ShoppingCart()
        {
            ShoppingList = new List<ShoppingItem>();
            Id = nextId;
            nextId++;
        }
        public static void addToShoppingCart(ShoppingItem itemToAdd, HttpContext session)
        {
            session.Items.Values.Add(itemToAdd.ToString());
        }

        public void removeFromShoppingCart(ShoppingItem itemToRemove, HttpContext session)
        {
            //WILL PROBABLY NOT BE ABLE TO PARTIALLY REMOVE. E.G REMOVE 2 STAPLERS FROM AN ORIGINAL ORDER OF 4
            session.Items.Values.Remove(itemToRemove);
        }

        public static List<ShoppingItem> GetShoppingCartList(HttpContext session)
        {
            var list = new List<ShoppingItem>();

            foreach (var item in session.Items.Values)
            {
                var tempItem = (ShoppingItem)item;
                list.Add(tempItem);
            }
            return list;
        
        }
    }
    
}
