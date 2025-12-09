using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace ExamenParcial2_Progra3.Models
    {
    public class Meta
        {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaLimite { get; set; }

        //FKs
        public int CategoriaMetaId { get; set; }
        public CategoriaMeta Categoria { get; set; }

        public int PrioridadMetaId { get; set; }
        public PrioridadMeta Prioridad { get; set; }

        public int EstadoMetaId { get; set; }
        public EstadoMeta Estado { get; set; }

        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
        }
    }