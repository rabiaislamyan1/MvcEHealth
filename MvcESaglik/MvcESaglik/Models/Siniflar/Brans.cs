using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcESaglik.Models.Siniflar
{
    public class Brans
    {
        [Key]
        [Display(Name = "Branş ID")]
        public int BransID { get; set; }

        [Column(TypeName = "nvarchar")]
        [Required(ErrorMessage = "Lütfen bir branş giriniz.")]
        [Display(Name = "Branş İsmi")]
        public string BransAd { get; set; }

        ICollection<DoktorProfil> DoktorProfils { get; set; }
    }
}