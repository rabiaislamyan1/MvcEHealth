using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Recete
    {
        [Key]
        [Display(Name = "Reçete No")]
        public int ReceteNo { get; set; }

        public DateTime Tarih { get; set; }

        public int Doktorid { get; set; }

        public virtual DoktorProfil DoktorProfil { get; set; }

        public string KullaniciProfilTcNo { get; set; }

        public virtual KullaniciProfil KullaniciProfil { get; set; }

        ICollection<ReceteIlac> ReceteIlacs { get; set; }
    }
}