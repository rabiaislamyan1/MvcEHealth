using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Kurum
    {
        [Key]
        [Display(Name = "Kurum ID")]
        public int KurumID { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Lütfen bir kurum adı giriniz.")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter girebilirsin.")]
        [Display(Name = "Kurum Adı")]
        public string KurumAd { get; set; }

        public int İlid { get; set; }

        public virtual İl İl { get; set; }

        public int İlceid { get; set; }

        public virtual İlce İlce { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsin.")]
        public bool Durum { get; set; }

        ICollection<DoktorProfil> DoktorProfils { get; set; }

        ICollection<Asi> Asis { get; set; }

        ICollection<Randevu> Randevus { get; set; }

        ICollection<Tahlil> Tahlils { get; set; }
    }
}