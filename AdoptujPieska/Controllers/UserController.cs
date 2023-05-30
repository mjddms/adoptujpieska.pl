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
        DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString);

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
            user.ROLE = 2;

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
                
            
            ModelState.Clear();
            ViewBag.SuccessMessage = "Zarejestrowano pomyślnie!";
            return View("Login", new User());
        }
        public ActionResult Login(User user)
        {
            var loggedInUser = db.User.FirstOrDefault(x => x.USERNAME == user.USERNAME && x.PASSWORD == user.PASSWORD);
            if (loggedInUser != null)
            {
                Session["UserName"] = loggedInUser.USERNAME;
                Session["Role"] = loggedInUser.ROLE;
                Session["Id"] = loggedInUser.Id;
                return RedirectToAction("Home", loggedInUser);
            }
            else
            {
                return View();
            }

        }

        public ActionResult Home(int id)
        {   
            User user =  db.User.SingleOrDefault(x=>x.Id == id);
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(user);
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


        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
        

    }
}