using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class KullaniciProfil
    {
        [Key]
        [Column(TypeName = "char")]
        [StringLength(11)]
        [Display(Name = "Tc Kimlik No")]
        public string TcNo { get; set; }

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Kullanıcı Soyadı")]
        public string KullaniciSoyad { get; set; }

        [Column(TypeName = "nvarchar")]
        public string Cinsiyet { get; set; }

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Aile Hekimi")]
        public string AileHekimi { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        [Display(Name = "Kullanıcı Görseli")]
        public string KullaniciGorsel { get; set; }

        [Display(Name = "Yaş")]
        public int Yas { get; set; }

        public float Kilo { get; set; }

        public float Boy { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        [Display(Name = "Kan Grubu")]
        public string KanGrubu { get; set; }

        [Column(TypeName = "char")]
        [StringLength(11)]
        [Display(Name = "Kullanıcı İletişim Numarası")]
        public string TelNo { get; set; }

        [Column(TypeName = "varchar")]
        [Display(Name = "Kullanıcı Maili")]
        public string KullaniciMail { get; set; }

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Kullanıcı Şifre")]
        public string KullaniciSifre { get; set; }

        ICollection<Alerji> Alerjis { get; set; }

        ICollection<Asi> Asis { get; set; }

        ICollection<Hastalik> Hastaliks { get; set; }

        ICollection<Randevu> Randevus { get; set; }

        ICollection<Rapor> Rapors { get; set; }

        ICollection<Recete> Recetes { get; set; }

        ICollection<Tahlil> Tahlils { get; set; }

        ICollection<ReceteIlac> ReceteIlacs { get; set; }

        ICollection<Yorum> Yorums { get; set; }

        public bool Durum { get; set; }
    }
}