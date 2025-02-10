using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Hastalik
    {
        [Key]
        [Display(Name = "Hastalık ID")]
        public int HastalikID { get; set; }

        [Display(Name = "Tanının Konulduğu Tarih")]
        public DateTime Tarih { get; set; }

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Tanı")]
        public string Tani { get; set; }

        public int Klinikid { get; set; }

        public virtual Klinik Klinik { get; set; }

        public int Doktorid { get; set; }

        public virtual DoktorProfil DoktorProfil { get; set; }

        public string KullaniciProfilTcNo { get; set; }

        public virtual KullaniciProfil KullaniciProfil { get; set; }
    }
}