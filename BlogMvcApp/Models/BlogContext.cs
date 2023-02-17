using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    // Uygulamada CodeFirst kullanabilmek için ekliyoruz. Uygulama içerisindeki veritabanı işlemlerimizi yapmamızı sağlayacak.
    // Kalıtım vererek EntityFramework context özelliklerini blogcontext e kazandırmış olduk.
    
    public class BlogContext:DbContext
    {
        /* :base(!!) ile kalıtım vermezsek Veritabanının adı : BlogMvcApp.ModelsBlogContext olarak kaydolur.
            Burada :base("!!") !! yerine db in ismini belirtebiliriz veya başka bir sunucudaki veritabanı üzerinden 
            işlemlerimizi gerçekleştireceksek Web.config de connectionstring tanımlarız ve adını buraya veririz.
            çalıştığında ilk web.config i kontrol eder orada bir yönlendirme varsa onu yapar yoksa verdiğin ad ile local de oluşturur.
         */
        public BlogContext()  // : base("!!") yeri
        { 
            Database.SetInitializer(new BlogInitializer());
        }


        //Burada Belirttiğimiz field lar VT da Tablo olarak duracak burada belirtmediysek vt Böyle bir tablo eklenmez.Mesela suan kullandığımız BlogModel ve CategoryModel gibi..
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Category> Kategoriler { get; set; }
    }
}