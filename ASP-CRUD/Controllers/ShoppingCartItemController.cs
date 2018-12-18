using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_CRUD.Models;
using ASP_CRUD.Models.ViewModels;

namespace ASP_CRUD.Controllers
{
    public class ShoppingCartItemController : Controller
    {
        public IActionResult Index()
        {
            ShoppingCartItemViewModel slm = new ShoppingCartItemViewModel();
            slm.carts = ShoppingCartItemRepository.GetShoppingCartItems();
                        
            return View(slm);
        }

        public IActionResult NewShoppingCartItem()
        {
            return View();
        }

        public IActionResult Create(string ShoppingCartID, int Quantity, int ProductID)
        {
            ShoppingCartItemModel cartItem = new ShoppingCartItemModel()
            {
                ShoppingCartID = ShoppingCartID,
                Quantity = Quantity,
                ProductID = ProductID
            };

            ShoppingCartItemRepository.CreateShoppingCartItem(cartItem);
            return RedirectToAction("Index", "ShoppingCartItem");
        }

        public IActionResult UpdateCartItem(int shoppingCartItemID, string shoppingCartID, int quantity, int productID)
        {
            ShoppingCartItemModel cart = new ShoppingCartItemModel()
            {
                ShoppingCartItemID = shoppingCartItemID,
                ShoppingCartID = shoppingCartID,
                Quantity = quantity,
                ProductID = productID
            };

            return View(cart);
        }

        public IActionResult Update(int shoppingCartItemID, string shoppingCartID, int quantity, int productID)
        {
            ShoppingCartItemModel cart = new ShoppingCartItemModel()
            {
                ShoppingCartItemID = shoppingCartItemID,
                ShoppingCartID = shoppingCartID,
                Quantity = quantity,
                ProductID = productID
            };

            ShoppingCartItemRepository.UpdateShoppingCartItem(cart);
            return RedirectToAction("Index", "ShoppingCartItem");
        }

        public IActionResult DeleteCartItem(int ShoppingCartItemID)
        {
            ShoppingCartItemRepository.DeleteShoppingCartItem(ShoppingCartItemID);
            return RedirectToAction("Index", "ShoppingCartItem");
        }
    }
}