using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Alerji
    {
        [Key]
        [Display(Name = "Alerji ID")]
        public int AlerjiID { get; set; }

        [Required(ErrorMessage = "Lütfen bir alerji giriniz.")]
        [Display(Name = "Alerji Adı")]
        public string AlerjiAd { get; set; }

        public string KullaniciProfilTcNo { get; set; }

        public virtual KullaniciProfil KullaniciProfil { get; set; }
    }
}