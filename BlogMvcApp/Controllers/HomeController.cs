using BlogMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();
       
        // GET: Home
        public ActionResult Index()
        {
            /*
             * Burada Onaylanmış ve Anasayfada gözükebilir olanları filtreliyerek Anasayfada göstermeye çalışıyoruz.
             * baslık kısmı 100 karakterden uzunsa 100 karakter +...  yapıyoruz eğer 100 karakter ise direkt geliyor.
             * Yeni bir blogmodelcs oluşturuyoruz Blog.cs den farkı içinde içerik bulunmuyor.
             
             */
            var bloglar = context.Bloglar
                                 .Select(i => new BlogModel()
                                 {   
                                     Id = i.Id,
                                     Baslik=i.Baslik.Length>100?i.Baslik.Substring(0,100)+"...":i.Baslik,
                                     Aciklama = i.Aciklama,
                                     EklenmeTarihi = i.EklenmeTarihi,
                                     Anasayfa=i.Anasayfa,
                                     Onay=i.Onay,
                                     Resim=i.Resim,
                                 })
                                 .Where(i => i.Onay == true && i.Anasayfa == true);

            //bloglar.Tolist() yapmazsak IQueryable olarak kalmaya devam ediyor. Bu yukarıda yaptığımız filtreleme işlemi devam edebilir anlamına geliyor.Yani tam bir liste halinde değil veritanaından bilgiler alınarak oluşmamış diyebiliriz.
            return View(bloglar.ToList());
        }
    }
}