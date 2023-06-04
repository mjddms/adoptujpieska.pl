using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AdoptujPieska.Models;

namespace AdoptujPieska.Controllers
{
    public class HomeController : Controller
    {
        DBUserModelDataContext db = new DBUserModelDataContext(ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString);

        public ActionResult Index()
        {
            var pieski = db.Pieski.AsQueryable();
            ViewBag.Pieski = pieski.ToList();
            return View();
        }
        public ActionResult Donate()
        {
            List<User> shelters = db.User.Where(x => x.ROLE == 1).ToList();
            return View(shelters);
        }

        public ActionResult Forms()
        {
            int userId = (int)Session["Id"];

            // Pobierz wszystkie rekordy z tabeli Pieski, które mają IdUser równe zalogowanemu użytkownikowi
            List<Pieski> userDogs = db.Pieski.Where(p => p.IdUser == userId).ToList();

            // Pobierz identyfikatory piesków
            List<int> dogIds = userDogs.Select(d => d.Id).ToList();

            // Pobierz wszystkie formularze przypisane do rekordów zgodnych z identyfikatorami piesków
            List<FormSchel> userForms = db.FormSchel.Where(f => dogIds.Contains((int)f.idDog)).ToList();

            return View(userForms);
        }

        public ActionResult About()
        {
            return View();
        }


    }
}