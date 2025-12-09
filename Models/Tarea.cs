using System.ComponentModel.DataAnnotations;

namespace ExamenParcial2_Progra3.Models
    {
    public class Tarea
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaLimite { get; set; }
        [Required]
        public int DificultadId {get; set; }
        public Dificultad Dificultad { get; set; }
        public double TiempoEstimadoHoras { get; set; }

        // FK EstadoTarea
        public int EstadoTareaId { get; set; }
        public EstadoTarea Estado { get; set; }

        // FK Meta
        public int MetaId { get; set; }
        public Meta Meta { get; set; }

        }
    }
