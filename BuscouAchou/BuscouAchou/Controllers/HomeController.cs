using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuscouAchou.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View("_Cadastro");
        }

        public ActionResult Receitas()
        {
            return View("_Receitas");
        }

        public ActionResult DadosUsua()
        {
            return View("_DadosUsua");
        }

        public ActionResult CadReceitas()
        {
            return View("_CadReceitas");
        }

    }
}
