using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Rapor
    {
        [Key]
        [Display(Name = "Rapor No")]
        public int RaporNo { get; set; }

        [Display(Name = "Veriliş Tarihi")]
        public DateTime VerilisTarihi { get; set; }

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Rapor Türü")]
        public string RaporTur { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        public DateTime BaslangicTarihi { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        public DateTime BitisTarihi { get; set; }

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Tanı")]
        public string Tani { get; set; }

        public string KullaniciProfilTcNo { get; set; }

        public virtual KullaniciProfil KullaniciProfil { get; set; }
    }
}