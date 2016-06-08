using BuscouAchou.Domain.Entities;
using BuscouAchou.Models;
using BuscouAchouRepository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BuscouAchou.Controllers
{
    public class HomeController : Controller
    {
        Repository repository = new Repository();

        public ActionResult Index()
        {

            try
            {
                var usuarioLogado = Session["codUsua"];
                if (usuarioLogado == null)
                    return View("index");

                return View("index", usuarioLogado);
            } 
            catch(Exception ex)
            {
                return View("Error", ex.Message);
            }

        }

        public ActionResult Cadastro()
        {
            return View("_Cadastro");
        }

        public ActionResult Login()
        {
            return View("_Login");
        }

        [HttpPost]
        public ActionResult PostUsuario(BAR_Usuario entitie)
        {
            try
            {
                repository.Post(entitie);
                return null;
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

        }

        public ActionResult VerificaEmail(string Email) 
        {
            try
            {
                var request = repository.VerificaEmail(Email);
                if(request == 1)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex) 
            {
                return View("Error", ex.Message);
            }
        
        }

        public ActionResult UsuarioLogado(string Email, string senha)
        {
            try
            {
                UnicodeEncoding encoding = new UnicodeEncoding();
                byte[] hashBytes;
                using (HashAlgorithm hash = SHA1.Create())
                    hashBytes = hash.ComputeHash(encoding.GetBytes(senha));

                StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
                foreach (byte b in hashBytes)
                {
                    hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
                }

                var request = repository.UsuarioLogado(Email, hashValue.ToString());
                if (request == 1)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                Session["codUsua"] = request.ToString();
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

        }

        public ActionResult Receitas()
        {
            ViewBag.filename = "teste2.jpg";
            return View("_Receitas");
        }

        public ActionResult DadosUsua()
        {
            try 
            {
                var codusua = Convert.ToInt32(Session["codUsua"]);
                var response = new BAR_Usuario();
                 response = repository.GetDadosUsuario(codusua);
                return View("_DadosUsua",response);
            }
            catch(Exception ex)
            {
                return View("Error", ex.Message);
            }


        }

        public ActionResult PutDadosUsua(BAR_Usuario entitie) 
        {
            try
            {
                var codUsua = Convert.ToInt32(Session["codUsua"]);
                repository.PutDadosUsuario(codUsua, entitie);
                return null;
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
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

        public ActionResult Sair() 
        {
            Session["codUsua"] = "";
            return RedirectToAction("index");
        }
   }
}
