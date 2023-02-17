using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class Category
    {
        //birincil anahtar olduğunu otomatik anlaması için Id yazmamız yeterli.
        // Eğer Farklı bir isim verip birincil anahtar olduğunu belirteceksek üzerine [Key] yazarız.
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        public List<Blog> Bloglar { get; set; }


    }
}