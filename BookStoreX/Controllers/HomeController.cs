
using BookStoreX.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStoreX.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;

            ViewBag.Books = books;

            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy (Purchase purchase)
        {
            purchase.PurchaseDate = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return (purchase.PersonName + ", спасибо за покупку!");
        }
            
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return NotFound("Вы не указали id книги");
            }

            Book book = db.Books.Find(id);

            if(book!=null)
            {
                return View(book);  
            }
            return NotFound("Вы такой книги нет");
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(book);
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book b = db.Books.Find(id);
            if (b ==null)
            {
                return NotFound();
            }
            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return NotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ViewBook (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = db.Books.Find(id);

            if (book != null)
            {
                return View(book);
            }

            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                db.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(user);
        }
        //Logout
        //Login
        //ViewUser
    }
}
