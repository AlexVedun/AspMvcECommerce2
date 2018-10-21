using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMvcECommerce2.WebUI.Models
{
    public class ApiResponse<T>
    {
        public T data { get; set; }
        public string error { get; set; }
    }
}