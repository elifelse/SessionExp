using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SessionExp.Models
{
    public class Kisi
    {
        [Display(Name = "Adınız")]
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [MaxLength(20, ErrorMessage = "{0} en fazla {1} karakter içerebilir.")]
        public string Ad { get; set; }
    }
}
