using AdoptujPieska.Models;
using AdoptujPieska.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;

namespace AdoptujPieska.Controllers
{
    public class PieskiController : Controller
    {
        // GET: Pieski
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(Pieski piesek)
        {
            using (DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                if (piesek.Imie != null)
                {
                    db.Pieski.InsertOnSubmit(piesek);
                    db.SubmitChanges();
                }
                else
                {
                    ViewBag.DuplicateMessage = "Wystąpił błąd!";
                }

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Dodoano pomyślnie!";
            return View();

        }
        public ActionResult All(Pieski piesek)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                var pieski = db.Pieski.ToList();
                ViewBag.Pieski = pieski;
            }
            return View();

        }

        public ActionResult Edit(int id)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                var piesek = db.Pieski.FirstOrDefault(p => p.Id == id);
                if (piesek != null)
                {
                    return View("Edit", piesek);
                }
            }
            return RedirectToAction("All");
        }


        public ActionResult Update(Pieski piesek)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))

            {
                var piesekToUpdate = db.Pieski.FirstOrDefault(p => p.Id == piesek.Id);
                if (piesekToUpdate != null)
                {
                    piesekToUpdate.Rasa = piesek.Rasa;
                    piesekToUpdate.Imie = piesek.Imie;
                    piesekToUpdate.Wiek = piesek.Wiek;
                    piesekToUpdate.Plec = piesek.Plec;
                    db.SubmitChanges();
                    return RedirectToAction("All");
                }

            }
            return RedirectToAction("Edit", new { id = piesek.Id });
        }


        public ActionResult Delete(int id)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                var piesekToDelete = db.Pieski.FirstOrDefault(p => p.Id == id);
                if (piesekToDelete != null)
                {
                    db.Pieski.DeleteOnSubmit(piesekToDelete);
                    db.SubmitChanges();
                }
            }
            return RedirectToAction("All");
        }
        
        public new ActionResult Profile(int? id)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                var pies = db.Pieski.SingleOrDefault(p => p.Id == id);
                if (pies == null)
                {
                    return HttpNotFound();
                }
                return View(pies);
            }
        }

    }
}
