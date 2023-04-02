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
            using (DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString))
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
            using (var db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString))
            {
                var pieski = db.Pieski.ToList();
                ViewBag.Pieski = pieski;
            }
            return View();

        }

    }
}