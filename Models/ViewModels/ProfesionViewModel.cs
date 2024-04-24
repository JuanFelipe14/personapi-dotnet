using System.ComponentModel.DataAnnotations;

namespace personapi_dotnet.Models.ViewModels
{
    public class ProfesionViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nom { get; set; } = null!;

        [Display(Name = "Descripción")]
        public string? Des { get; set; }
    }
}
