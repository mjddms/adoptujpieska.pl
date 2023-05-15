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
                if (file != null && file.ContentLength > 0) 
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                    file.SaveAs(path);

                    piesek.Zdjecie = "/uploads/" + fileName;
                }

                db.Pieski.InsertOnSubmit(piesek);
                db.SubmitChanges();
            }

            return RedirectToAction("All");
        }


        public ActionResult All(Pieski piesek, string aktywny, string lubi_dzieci, string lubi_psy, string plec, string rasa, int? wiek)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                var pieski = db.Pieski.AsQueryable();

                if (!string.IsNullOrEmpty(rasa))
                {
                    pieski = pieski.Where(p => p.Rasa.Contains(rasa));
                    ViewBag.WybranaRasa = rasa;
                }

                if (wiek.HasValue)
                {
                    pieski = pieski.Where(p => p.Wiek == wiek);
                    ViewBag.WybranyWiek = wiek;
                }

                if (!string.IsNullOrEmpty(aktywny))
                {
                    bool aktywnyBool = aktywny == "tak";
                    pieski = pieski.Where(p => p.Aktywny == aktywnyBool);
                }

                if (!string.IsNullOrEmpty(lubi_dzieci))
                {
                    bool lubiDzieciBool = lubi_dzieci == "tak";
                    pieski = pieski.Where(p => p.Lubi_dzieci == lubiDzieciBool);
                }

                if (!string.IsNullOrEmpty(lubi_psy))
                {
                    bool lubiPsyBool = lubi_psy == "tak";
                    pieski = pieski.Where(p => p.Lubi_psy == lubiPsyBool);
                }

                if (!string.IsNullOrEmpty(plec))
                {
                    bool plecBool = plec == "samica";
                    pieski = pieski.Where(p => p.Plec == plecBool);
                }


                ViewBag.Pieski = pieski.ToList();
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


        public ActionResult Update(int id)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                Pieski piesek = db.Pieski.SingleOrDefault(x => x.Id == id);
                if (piesek == null)
                {
                    return HttpNotFound();
                }

                return View(piesek);
            }
        }

        [HttpPost]
        public ActionResult Update(Pieski piesek, HttpPostedFileBase file)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                Pieski piesekToUpdate = db.Pieski.SingleOrDefault(x => x.Id == piesek.Id);
                if (piesekToUpdate == null)
                {
                    return HttpNotFound();
                }

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                    file.SaveAs(path);

                    piesekToUpdate.Zdjecie = "/uploads/" + fileName;
                }

                piesekToUpdate.Rasa = piesek.Rasa;
                piesekToUpdate.Imie = piesek.Imie;
                piesekToUpdate.Wiek = piesek.Wiek;
                piesekToUpdate.Plec = piesek.Plec;
                piesekToUpdate.Aktywny = piesek.Aktywny;
                piesekToUpdate.Lubi_dzieci = piesek.Lubi_dzieci;
                piesekToUpdate.Lubi_psy = piesek.Lubi_psy;
                piesekToUpdate.Opis = piesek.Opis;


                db.SubmitChanges();
            }

            return RedirectToAction("All");
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
        
        public new ActionResult Profile(int id)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                var pies = db.Pieski.SingleOrDefault(p => p.Id == id);
                if (pies == null)
                {
                    return HttpNotFound();
                }
                else 
                {
                        var zdjecia = db.Photo.Where(p => p.IdDog == id).ToList();
                        if (zdjecia != null)
                            ViewBag.Photos = zdjecia;
                    
                }
                return View(pies);
            }
        }
        public ActionResult Photos(int id)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                Pieski piesek = db.Pieski.SingleOrDefault(x => x.Id == id);
                if (piesek == null)
                {
                    return HttpNotFound();
                }

                return View(piesek);
            }
        }
        [HttpPost]
        public ActionResult Photos(HttpPostedFileBase file, int id)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                var piesek = db.Pieski.FirstOrDefault(p => p.Id == id);
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                    file.SaveAs(path);

                    Photo photo = new Photo();
                    photo.Photos = "/uploads/" + fileName;
                    photo.Pieski = piesek;
                    piesek.Photo.Add(photo);
                    db.SubmitChanges();
                } 
                return View("Profile",piesek);
            }
           
        }
        public ActionResult PrintPhotos(int id)
        {
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString))
            {
                var zdjecia = db.Photo.Where(p => p.IdDog == id).ToList();
                if (zdjecia != null)
                    ViewBag.Photos = zdjecia;
            }
            return View();
        }



    }
}
