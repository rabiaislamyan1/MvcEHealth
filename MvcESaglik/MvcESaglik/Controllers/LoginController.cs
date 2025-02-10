using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcESaglik.Models.Siniflar;
using System.Web.Security;

namespace MvcESaglik.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(KullaniciProfil p)
        {
            c.KullaniciProfils.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult DoktorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoktorLogin(DoktorProfil d)
        {
            var bilgiler = c.DoktorProfils.FirstOrDefault(x => x.DoktorMail == d.DoktorMail && x.DoktorSifre == d.DoktorSifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.DoktorMail, false);
                Session["DoktorMail"] = bilgiler.DoktorMail.ToString();
                return RedirectToAction("Index", "DoktorPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "KullaniciProfil");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult KullaniciLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciLogin(KullaniciProfil p)
        {
            var bilgiler = c.KullaniciProfils.FirstOrDefault(x => x.TcNo == p.TcNo && x.KullaniciSifre == p.KullaniciSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.TcNo, false);
                Session["TcNo"] = bilgiler.TcNo.ToString();
                return RedirectToAction("Index", "KullaniciPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}