using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdoptujPieska.Models;
using System.ComponentModel.DataAnnotations;

namespace AdoptujPieska.Controllers
{

    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register(int id = 0)
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Register(User user)
        {

            if (!ModelState.IsValid)
            {
                return View("Register", user);
            }

            using (DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                if (db.User.Any(x => x.USERNAME == user.USERNAME))
                {
                    ViewBag.DuplicateMessage = "Użytkownik o takiej nazwie już istnieje!";
                    return View("Register", user);
                }
                else
                {
                    db.User.InsertOnSubmit(user);
                    db.SubmitChanges();
                }

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Zarejestrowano pomyślnie!";
            return View("Login", new User());
        }
        public ActionResult Login(User user)
        {
            DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString);


            var users = db.User.Where(x => x.USERNAME == user.USERNAME && x.PASSWORD == user.PASSWORD).Count();
            if (users > 0)
            {
                Session["UserName"] = user.USERNAME;
                return RedirectToAction("Home");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Home()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Manage()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                string username = Session["UserName"].ToString();

                using (DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
                {
                    User user = db.User.SingleOrDefault(x => x.USERNAME == username);

                    if (user == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return View(user);
                    }
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            else if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                string username = Session["UserName"].ToString();

                using (DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
                {
                    User existingUser = db.User.SingleOrDefault(x => x.USERNAME == username);

                    if (existingUser == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                    if (db.User.Any(x => x.USERNAME == user.USERNAME && x.Id != user.Id))
                    {
                        ViewBag.DuplicateMessage = "Użytkownik o takiej nazwie już istnieje!";
                        return View("Edit", user);
                     }
                        existingUser.USERNAME = user.USERNAME;
                        
                        existingUser.EMAIL = user.EMAIL;
                        existingUser.PASSWORD = user.PASSWORD;
                        db.SubmitChanges();

                        Session["UserName"] = user.USERNAME;

                        ViewBag.SuccessMessage = "Dane użytkownika zostały zaktualizowane.";
                        return View("Home", existingUser);
                    }
                }
            }
        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Home/Index");
        }
        

    }
}