using System.ComponentModel.DataAnnotations;

namespace ExamenParcial2_Progra3.Models
    {
    public class Dificultad
        {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
        }
    }

