using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_CRUD.Models.ViewModels
{
    public class ShoppingCartItemViewModel
    {
        public List<ShoppingCartItemModel> carts { get; set; }
        public int ShoppingCartItemID { get; set; }
        public string ShoppingCartID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
