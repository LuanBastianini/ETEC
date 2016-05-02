using BuscouAchou.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuscouAchou.Controllers
{
    public class HomeController : Controller
    {
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

            ViewBag.filename = "teste2.jpg";
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

        [HttpPost]
        public ActionResult CadReceitas(ImagensModel imagem)
        {
            if (imagem.file.ContentLength > 0) 
            {
                var filename = "teste2";
                var path = Path.Combine(Server.MapPath("~/Content/ImagemReceitas"), filename+".jpg");
                imagem.file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        public ActionResult MinhasReceitas() 
        {
            return View("_MinhasReceitas");        
        }

        public ActionResult AlterarReceita()
        {
            return View("_AltReceita");
        }

    }
}
