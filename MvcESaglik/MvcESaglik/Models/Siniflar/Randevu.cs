using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Randevu
    {
        [Key]
        [Display(Name = "Randevu No")]
        public int RandevuNo { get; set; }

        public int İlid { get; set; }

        public virtual İl İl { get; set; }

        public int İlceid { get; set; }

        public virtual İlce İlce { get; set; }

        [Display(Name = "Randevu Tarihi")]
        public DateTime Tarih { get; set; }

        public int Kurumid { get; set; }

        public virtual Kurum Kurum { get; set; }

        public int Klinikid { get; set; }

        public virtual Klinik Klinik { get; set; }

        public int Doktorid { get; set; }

        public virtual DoktorProfil DoktorProfil { get; set; }

        public string KullaniciProfilTcNo { get; set; }

        public virtual KullaniciProfil KullaniciProfil { get; set; }

        public bool Durum { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }
    }
}