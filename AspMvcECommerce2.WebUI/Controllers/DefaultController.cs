using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcECommerce2.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ViewResult Index()
        {
            return View();
        }
    }
}