using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string Sifre { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}