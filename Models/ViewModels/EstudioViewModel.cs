using System.ComponentModel.DataAnnotations;

namespace personapi_dotnet.Models.ViewModels
{
    public class EstudioViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int IdProf { get; set; }
        [Required]
        [Display(Name = "Documento Persona")]

        public int CcPer { get; set; }

        [Display(Name = "Fecha")]
        public DateOnly? Fecha { get; set; }

        [Display(Name = "Universidad")]
        public string? Univer { get; set; }
    }
}
