using System.ComponentModel.DataAnnotations;

namespace personapi_dotnet.Models.NewFolder
{
    public class PersonaViewModel
    {
        [Required]
        [Display(Name = "Documento")]
        public int Cc { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = null!;

        [Required]
        [Display(Name = "Género")]
        public string Genero { get; set; } = null!;

        [Display(Name = "Edad")]
        public int? Edad { get; set; }
    }
}
