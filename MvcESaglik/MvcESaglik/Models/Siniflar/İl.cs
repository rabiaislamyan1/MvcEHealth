using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class İl
    {
        [Key]
        [Display(Name = "İl ID")]
        public int İlID { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Lütfen bir il adı giriniz.")]
        [StringLength(40, ErrorMessage = "En fazla 40 karakter girebilirsin.")]
        [Display(Name = "İl Adı")]
        public string İlAd { get; set; }

        ICollection<İlce> İlces { get; set; }

        ICollection<Kurum> Kurums { get; set; }

        ICollection<Randevu> Randevus { get; set; }

        public bool Durum { get; set; }
    }
}