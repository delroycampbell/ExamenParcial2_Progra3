using System.ComponentModel.DataAnnotations;

namespace ExamenParcial2_Progra3.Models
    {
    public class PrioridadMeta
        {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Meta> Metas { get; set; } = new List<Meta>();
        }
    }
