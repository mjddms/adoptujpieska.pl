using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdoptujPieska.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.IO;
using System.Web.Security;

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
        public new ActionResult Profile(int id)
        {
            User user = db.User.SingleOrDefault(x => x.Id == id);

                return View(user);

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
        public ActionResult Edit(User user, HttpPostedFileBase file)
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
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                        file.SaveAs(path);

                        existingUser.PHOTO = "/uploads/" + fileName;
                    }
                    existingUser.USERNAME = user.USERNAME;
                        
                        existingUser.EMAIL = user.EMAIL;
                        existingUser.PASSWORD = user.PASSWORD;
                        if(existingUser.ROLE == 1)
                        {
                            existingUser.PHONE = user.PHONE;
                            existingUser.ADDRESS = user.ADDRESS;
                            existingUser.DESCRIPTION = user.DESCRIPTION; 
                        }
                        db.SubmitChanges();

                        Session["UserName"] = user.USERNAME;

                        ViewBag.SuccessMessage = "Dane użytkownika zostały zaktualizowane.";
                        return View("Home", existingUser);
                    }
                
            }
        }

        public ActionResult Shelters()
        {
            List<User> shelters = db.User.Where(x => x.ROLE == 1).ToList();
            return View(shelters);

        }
        public ActionResult Users()
        {
            List<User> users = db.User.ToList();
            return View(users);

        }
        public ActionResult Delete(int id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                User user = db.User.SingleOrDefault(x => x.Id == id);

                if (user == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    List<Like> likes = db.Like.Where(x => x.IdUser == id).ToList();
                    db.Like.DeleteAllOnSubmit(likes);
                    List<Comments> com = db.Comments.Where(x => x.author == id).ToList();
                    db.Comments.DeleteAllOnSubmit(com);
                    db.User.DeleteOnSubmit(user);
                    db.SubmitChanges();

                    if ((int)Session["Role"]==0)
                    {
                        return RedirectToAction("Users");
                    }
                    else
                    {
                        Session.Abandon();
                        return RedirectToAction("Login");
                    }
                    
                }
            }
        }
        public ActionResult ChangeUserRole(int id, int role)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                User user = db.User.SingleOrDefault(x => x.Id == id);

                if (user == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    user.ROLE = role;
                    db.SubmitChanges();

                    TempData["SuccessMessage"] = "Rola użytkownika została zmieniona.";
                    return RedirectToAction("Users");
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