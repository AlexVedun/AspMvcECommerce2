using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMvcECommerce2.WebUI.Models
{
    public class CartItemDetails
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public int Count { get; set; }
        public decimal Summ { get; set; }
    }
}