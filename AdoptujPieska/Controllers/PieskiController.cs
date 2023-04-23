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
using System.IO;

namespace AdoptujPieska.Controllers
{
    public class PieskiController : Controller
    {
        // GET: Pieski
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int id = 0)
        {
            Pieski pieski = new Pieski();
            return View(pieski);
        }

        [HttpPost]
        public ActionResult Add(Pieski piesek, HttpPostedFileBase file)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                if (file != null && file.ContentLength > 0) // sprawdza, czy plik został przesłany
                {
                    // zapisuje zdjęcie na serwerze
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                    file.SaveAs(path);

                    // zapisuje ścieżkę do bazy danych
                    piesek.Zdjecie = "/uploads/" + fileName;
                }

                db.Pieski.InsertOnSubmit(piesek);
                db.SubmitChanges();
            }

            return RedirectToAction("All");
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
