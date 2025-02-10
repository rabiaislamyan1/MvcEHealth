using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Asi
    {
        [Key]
        [Display(Name = "Aşı ID")]
        public int AsiID { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Lütfen bir alerji giriniz.")]
        [Display(Name = "Aşı Adı")]
        public string AsiAd { get; set; }

        [Display(Name = "Yapıldığı Tarih")]
        public DateTime AsiTarihi { get; set; }

        public int Kurumid { get; set; }

        public virtual Kurum Kurum { get; set; }

        public string KullaniciProfilTcNo { get; set; }

        public virtual KullaniciProfil KullaniciProfil { get; set; }
    }
}