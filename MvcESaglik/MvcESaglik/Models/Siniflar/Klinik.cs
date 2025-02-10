using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Klinik
    {
        [Key]
        [Display(Name = "İl ID")]
        public int KlinikID { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Lütfen bir klinik adı giriniz.")]
        [StringLength(70, ErrorMessage = "En fazla 70 karakter girebilirsin.")]
        [Display(Name = "Klinik Adı")]
        public string KlinikAd { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsin.")]
        public bool Durum { get; set; }

        ICollection<Hastalik> Hastaliks { get; set; }

        ICollection<Randevu> Randevus { get; set; }
    }
}