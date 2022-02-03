using System;
using System.Collections.Generic;
using System.Globalization;
using WTechECommerce.Business.Manager.ProductManager;
using WTechECommerce.Data.ORM.Entites;

namespace WTechECommerce.UI.Models.Helper
{
    public class CartHelper
    {
       public static List<ProductCartItemVM> GetCartProducts(UserCart userCart)
        {
         

            List<ProductCartItemVM> model = new List<ProductCartItemVM>();

            if (userCart != null)
            {
                decimal totalPrice = 0;
                foreach (var item in userCart.UserCartItems)
                {
                    ProductCartItemVM productCartItem = new ProductCartItemVM();

                    Product product = ProductManager.GetProductById(item.ProductId);

                    productCartItem.Title = product.Name;
                    productCartItem.Description = product.Description;
                    productCartItem.UnitPrice = (product.UnitPrice * item.Quantity).ToString();
                    productCartItem.MainImg = product.MainImgPath;
                    productCartItem.Id = product.Id;

                    productCartItem.Quantity = item.Quantity;


                    model.Add(productCartItem);

                    totalPrice = totalPrice + (product.UnitPrice * item.Quantity);

                }
            }

            return model;


        }


        public static string GetTotalPriceWithCurrencyFormat(UserCart userCart)
        {
            decimal totalPrice = 0;
            foreach (var item in userCart.UserCartItems)
            {

                Product product = ProductManager.GetProductById(item.ProductId);
                totalPrice = totalPrice + (product.UnitPrice * item.Quantity);
            }

           var totalPriceWithCurrenyFormat =  totalPrice.ToString("c", CultureInfo.GetCultureInfo("tr-TR"));


            return totalPriceWithCurrenyFormat;
        }
    }
}
