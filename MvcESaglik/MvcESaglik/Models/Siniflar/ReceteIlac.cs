using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class ReceteIlac
    {
        [Key]
        [Display(Name = "Barkod")]
        [StringLength(13)]
        public string Barkod { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Lütfen bir ilaç ismi giriniz.")]
        [Display(Name = "İlaç Adı")]
        public string İlacAd { get; set; }

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        public double Doz { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Periyot { get; set; }

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Kullanım Şekli")]
        public string KullanimSekli { get; set; }

        [Display(Name = "Kullanım Adedi")]
        public int KullanimSayisi { get; set; }

        [Display(Name = "Kutu Adedi")]
        public int KutuAdedi { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        [Display(Name = "Görseli")]
        public string İlacGorsel { get; set; }

        public int Receteno { get; set; }

        public virtual Recete Recete { get; set; }

        public string KullaniciProfilTcNo { get; set; }

        public virtual KullaniciProfil KullaniciProfil { get; set; }
    }
}