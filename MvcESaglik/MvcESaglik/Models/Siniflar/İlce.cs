using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class İlce
    {
        [Key]
        [Display(Name = "İlçe ID")]
        public int İlceID { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Lütfen bir ilçe adı giriniz.")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsin.")]
        [Display(Name = "İlçe Adı")]
        public string İlceAd { get; set; }

        public int İlid { get; set; }

        public virtual İl İl { get; set; }

        ICollection<Kurum> Kurums { get; set; }

        ICollection<Randevu> Randevus { get; set; }

        public bool Durum { get; set; }
    }
}