using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddBook()
        {
            return View();
        }

        public ActionResult InsertBook(String title, String author, String cover, String imageurl)
        {
            StreamWriter file = new StreamWriter(Server.MapPath("~/" + Session["filename"]), true);
            file.Write(title + "\n");
            file.Write(author + "\n");
            file.Write(cover + "\n");
            file.Write(imageurl + "\n");
            file.Flush();
            file.Close();

            String line;
            List<List<String>> books = new List<List<String>>();
            StreamReader read = new StreamReader(Server.MapPath("~/" + Session["filename"]));
            while ((line = read.ReadLine()) != null)
            {
                List<String> book = new List<String>();
                book.Add(line);
                book.Add(read.ReadLine());
                book.Add(read.ReadLine());
                book.Add(read.ReadLine());
                
                books.Add(book);
            }
            
            Session["books"] = books;

            read.Close();

            return RedirectToAction("MyCollection");
            
        }

        public ActionResult MyCollection()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignIn(String user, String pw)
        {
            pw = pw.ToLower();
            string hash = pw.Replace("w", "q").Replace("e", "w").Replace("r", "e").Replace("t", "r").Replace("y", "t").Replace("u", "y")
                .Replace("i", "u").Replace("o", "i").Replace("p", "o").Replace("1", "a").Replace("s", "1").Replace("2", "s")
                .Replace("d", "2").Replace("3", "d").Replace("f", "3").Replace("4", "f").Replace("g", "4").Replace("5", "g")
                .Replace("h", "5").Replace("6", "h").Replace("j", "6").Replace("7", "j").Replace("k", "7").Replace("8", "k")
                .Replace("l", "8").Replace("9", "l").Replace("0", "9").Replace("z", "ek").Replace("x", "dp").Replace("c", "3p")
                .Replace("v", "00").Replace("b", "4i").Replace("n", "wa").Replace("m", "ni");
            hash = hash + "IS";
            string filename = user + hash + ".txt";

            StreamWriter log = new StreamWriter(Server.MapPath("~/" + filename), true);
            log.Close();

            Session["filename"] = filename;
            Session["logged"] = "logged";

            String line;
            List<List<String>> books = new List<List<String>>();
            StreamReader read = new StreamReader(Server.MapPath("~/" + filename));
            while ((line = read.ReadLine()) != null)
            {
                List<String> book = new List<String>();
                book.Add(line);
                book.Add(read.ReadLine());
                book.Add(read.ReadLine());
                book.Add(read.ReadLine());

                books.Add(book);
            }

            Session["books"] = books;

            read.Close();

            return RedirectToAction("Index");
        }

        public ActionResult SignOut()
        {
            Session["logged"] = null;
            return RedirectToAction("Login");
        }
    }
}