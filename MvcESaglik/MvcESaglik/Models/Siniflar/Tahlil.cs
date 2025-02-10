using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Tahlil
    {
        [Key]
        [Display(Name = "Tahlil No")]
        public int TahlilNo { get; set; }

        public int Kurumid { get; set; }

        public virtual Kurum Kurum { get; set; }


        [Display(Name = "İşlem Adı")]
        public string İslemAdi { get; set; }


        [Display(Name = "Sonuç")]
        public float Sonuc { get; set; }


        [Display(Name = "Referans Değeri")]
        public float ReferansDegeri { get; set; }

        public DateTime Tarih { get; set; }

        public string KullaniciProfilTcNo { get; set; }

        public virtual KullaniciProfil KullaniciProfil { get; set; }
    }
}