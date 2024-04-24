using personapi_dotnet.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace personapi_dotnet.Models.ViewModels
{
    public class TelefonoViewModel
    {
        [Required]
        [Display(Name="Telefono")]
        public string Num { get; set; } = null!;


        [Required]
        [Display(Name = "Operador")]
        public string Oper { get; set; } = null!;

        [Required]
        [Display(Name = "Dueño")]
        public int Duenio { get; set; }

    }
}
