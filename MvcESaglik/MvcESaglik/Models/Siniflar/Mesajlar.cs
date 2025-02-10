using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Gonderici { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Alici { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Konu { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(2000)]
        public string icerik { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}