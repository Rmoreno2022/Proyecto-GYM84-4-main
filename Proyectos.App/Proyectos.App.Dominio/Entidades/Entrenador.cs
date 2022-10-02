using System.ComponentModel.DataAnnotations;

namespace Proyectos.App.Dominio.Entidades
{
    public class Entrenador
    {
        //atributos de la clase entrenador
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required]        
        [Display(Name = "Nro. Identificación")]
        public string identificacion{ get; set; }
        [Required]        
        [Display(Name = "Nombre Del Entrenador")]
        public string nombre{ get; set; }
        [Required]   
        [Display(Name = "Apellido Del Entrenador")]
        public string apellido{ get; set; }
        [Required]
        [Display(Name = "Edad")]
        public string edad{ get; set; }
        [Required]      
        [Display(Name = "Correo Electrónico")]
        public string mail{ get; set; }
        [Required]        
        [Display(Name = "Celular")]
        public string movil{ get; set; }
         [Display(Name = "Vigente")]
         public bool vigente{ get; set; }
    }
}

