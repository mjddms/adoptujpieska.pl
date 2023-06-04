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
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using System.Data.Linq;
using System.Diagnostics;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Linq;
using System.Security.Principal;
using System.Web.UI.WebControls;


namespace AdoptujPieska.Controllers
{
   
    public class PieskiController : Controller
    {
        DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString);
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
            
            
                if (file != null && file.ContentLength > 0) 
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                    file.SaveAs(path);

                    piesek.Zdjecie = "/uploads/" + fileName;
                }
                int UserId = (int)Session["Id"];
                piesek.IdUser = UserId;
                db.Pieski.InsertOnSubmit(piesek);
                db.SubmitChanges();
            

            return RedirectToAction("All");
        }



        public ActionResult All(Pieski piesek, string aktywny, string lubi_dzieci, string lubi_psy, string plec, string rasa, int? wiek)
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
            

            return View();
        }

        public ActionResult Edit(int id)
        {
            
                var piesek = db.Pieski.FirstOrDefault(p => p.Id == id);
                if (piesek != null)
                {
                    return View("Edit", piesek);
                }
            
            return RedirectToAction("All");
        }


        public ActionResult Update(int id)
        {
         
                 Pieski piesek = db.Pieski.SingleOrDefault(x => x.Id == id);
                if (piesek == null)
                {
                    return HttpNotFound();
                }

                return View(piesek);
            
        }

        [HttpPost]
        public ActionResult Update(Pieski piesek, HttpPostedFileBase file)
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
            

            return RedirectToAction("All");
        }



    public ActionResult Delete(int id)
        {    
                var piesekToDelete = db.Pieski.FirstOrDefault(p => p.Id == id);
                if (piesekToDelete != null)
                {
                    db.Pieski.DeleteOnSubmit(piesekToDelete);
                    db.SubmitChanges();
                }
            
            return RedirectToAction("All");
        }
        
        public new ActionResult Profile(int id)
        {
            
            
                var pies = db.Pieski.SingleOrDefault(p => p.Id == id);
                if (pies == null)
                {
                    return HttpNotFound();
                }
            

            return View(pies) ;
            
        }
        public ActionResult Photos(int id)
        {
                Pieski piesek = db.Pieski.SingleOrDefault(x => x.Id == id);
                if (piesek == null)
                {
                    return HttpNotFound();
                }

                return View(piesek);
            
        }
        [HttpPost]
        public ActionResult Photos(HttpPostedFileBase file, int id)
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
                return View("Profile", piesek);
            
           
        }


        public ActionResult Like(int id) 
        {

            Pieski piesek = db.Pieski.SingleOrDefault(x => x.Id == id);
            int Uid = (int)Session["Id"];
            Like like = new Like();
            Like iflike = db.Like.SingleOrDefault(x => x.IdUser == Uid && x.LikeDog == id);
            if (iflike == null)
            {
                like.Pieski = piesek;
                like.IdUser = Uid;
                piesek.Like.Add(like);
                db.SubmitChanges();
                
            }
            else
            {
                db.Like.DeleteOnSubmit(iflike);
                db.SubmitChanges();
            }
            return View("Profile", piesek);
        }

        public ActionResult RemovePhoto(int Id)
        {
            Debug.WriteLine("Metoda RemovePhoto została wywołana.");

            var photo = db.Photo.SingleOrDefault(p => p.Id == Id);
            if (photo != null)
            {
                db.Photo.DeleteOnSubmit(photo);
                db.SubmitChanges();
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateForm(Pieski pies, string name, string surname, string phone, string message)
        {
            if (Session["Username"]==null)
            {
                return RedirectToAction("Login", "User"); // Przekierowanie na akcję logowania w kontrolerze Account
            }

            
            if (pies == null)
            {
                return View("~/Views/Shared/Error.cshtml"); // Przykład obsługi, jeśli nie znaleziono psa o podanym id
            }

            FormSchel formData = new FormSchel();

            int userId = (int)Session["Id"];
            formData.idDog = pies.Id;
            formData.idUser = userId;
            formData.name = name;
            formData.surname = surname;
            formData.phone = phone;
            formData.message = message;

            db.FormSchel.InsertOnSubmit(formData);
            db.SubmitChanges();
            return RedirectToAction("All");
         
        }


    }
}
