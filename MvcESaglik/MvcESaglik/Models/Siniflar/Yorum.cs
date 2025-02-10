using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Yorum
    {
        [Key]
        [Display(Name = "Yorum ID")]
        public int YorumID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        [Required(ErrorMessage = "Lütfen bir yorum giriniz.")]
        [Display(Name = "Yorum")]
        public string Yorumlama { get; set; }

        [Display(Name = "Yapıldığı Tarih")]
        public DateTime YorumTarihi { get; set; }

        public int Doktorid { get; set; }

        public virtual DoktorProfil DoktorProfil { get; set; }

        public string KullaniciProfilTcNo { get; set; }

        public virtual KullaniciProfil KullaniciProfil { get; set; }
    }
}