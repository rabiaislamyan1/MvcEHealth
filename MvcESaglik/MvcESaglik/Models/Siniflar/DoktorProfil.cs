using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class DoktorProfil
    {
        [Key]
        [Display(Name = "Doktor ID")]
        public int DoktorID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsin.")]
        [Display(Name = "Doktor Adı")]
        public string DoktorAd { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsin.")]
        [Display(Name = "Doktor Soyadı")]
        public string DoktorSoyad { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        [Display(Name = "Doktor Görseli")]
        public string DoktorGorsel { get; set; }

        [Display(Name = "Yaş")]
        public int Yas { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(5, ErrorMessage = "En fazla 5 karakter girebilirsin.")]
        public string Cinsiyet { get; set; }

        public int Bransid { get; set; }

        public virtual Brans Brans { get; set; }

        public int Kurumid { get; set; }

        public virtual Kurum Kurum { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsin.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi gir.")]
        [Display(Name = "Doktor Maili")]
        public string DoktorMail { get; set; }

        [Column(TypeName = "char")]
        [StringLength(11)]
        [Phone(ErrorMessage = "Lütfen geçerli bir telefon numarası gir.")]
        [Display(Name = "Doktor İletişim Numarası")]
        public string TelNo { get; set; }

        [Column(TypeName = "nvarchar")]
        [Range(6, 12, ErrorMessage = "En az 6, en fazla 12 karakter girebilirsin.")]
        [Display(Name = "Doktor Şifre")]
        public string DoktorSifre { get; set; }

        ICollection<Hastalik> Hastaliks { get; set; }

        ICollection<Randevu> Randevus { get; set; }

        ICollection<Recete> Recetes { get; set; }

        ICollection<Yorum> Yorums { get; set; }

        public bool Durum { get; set; }
    }
}