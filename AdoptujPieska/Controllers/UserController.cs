﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdoptujPieska.Models;

namespace AdoptujPieska.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register(int id=0)
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult Register(User user) 
        {
            using (DBUserModelDataContext db = new DBUserModelDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\natal\OneDrive\Pulpit\Nowy folder\AdoptujPieska\AdoptujPieska\App_Data\Database1.mdf"";Integrated Security=True"))
            {
                if(db.User.Any(x => x.USERNAME==user.USERNAME))
                {
                    ViewBag.DuplicateMessage = "Użytkownik o takiej nazwie już istnieje!";
                    return View("Register",user);
                }
                else 
                {
                    db.User.InsertOnSubmit(user);
                    db.SubmitChanges();
                }
               
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Zarejestrowano pomyślnie!";
            return View("Login",new User());
        }
        public ActionResult Login(User user)
        {
            DBUserModelDataContext db = new DBUserModelDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\dzied\OneDrive\Pulpit\AdoptujPieska\v1\AdoptujPieska\AdoptujPieska\App_Data\Database1.mdf"";Integrated Security=True");
            var users=db.User.Where(x => x.USERNAME == user.USERNAME && x.PASSWORD == user.PASSWORD).Count();
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

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}