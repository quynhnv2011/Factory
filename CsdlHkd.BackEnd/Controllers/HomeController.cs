using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Web.Controllers;
using Services;

namespace CsdlHkd.BackEnd.Controllers
{
    public class HomeController : BaseController
    {
        private AccountService _accountServices;
        public HomeController()
        {
            _accountServices = new AccountService(Provider);
        }
        // GET: Home
        public ActionResult Index()
        {
            _accountServices.GetById(1);
            return View();
        }
    }
}