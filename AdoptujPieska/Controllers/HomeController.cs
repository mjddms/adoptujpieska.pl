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
            return View();
        }
        public ActionResult Donate()
        {
            List<User> shelters = db.User.Where(x => x.ROLE == 1).ToList();
            return View(shelters);
        }


    }
}