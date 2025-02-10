using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Yapilacak
    {
        [Key]
        public int Yapilacakid { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Column(TypeName = "bit")]
        public bool Durum { get; set; }

    }
}