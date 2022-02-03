using System;
using System.Collections.Generic;

namespace WTechECommerce.UI.Models
{
    public class OrderVM
    {
        public List<ProductCartItemVM> productCartItemVMs { get; set; }

        public OrderPostVM orderPostVM { get; set; }
    }
}
