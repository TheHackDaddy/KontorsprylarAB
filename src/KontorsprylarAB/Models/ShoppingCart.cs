using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KontorsprylarAB.Models
{
    public class ShoppingCart
    {
        //NEEDS PROP TO IDENTIFY WHICH USERS SHOPPING CART IT IS
        public List<ShoppingItem> ShoppingList { get; set; }

        public void addToShoppingCart(ShoppingItem itemToAdd)
        {
            ShoppingList.Add(itemToAdd);
        }

        public void removeFromShoppingCart(ShoppingItem itemToRemove)
        {
            ShoppingList.Remove(itemToRemove);
        }
    }

    
}
