using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            Book book = new Book();
            book.Title = "Jurassic Park";
            book.Author = "Michael Crichton";
            return View();
        }
    }
}