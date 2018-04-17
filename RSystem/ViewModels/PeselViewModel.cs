using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RSystem.Models;

namespace RSystem.ViewModels
{
    public class PeselViewModel
    {
        [Required(ErrorMessage = "Proszę podać PESEL.")]
        [RegularExpression(@"^[0-9]{11}$",ErrorMessage = "PESEL powinien skladać się z 11 cyfr.")]
        public string PESEL { get; set; }
    }
}