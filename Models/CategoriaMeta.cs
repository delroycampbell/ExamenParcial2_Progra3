using System.ComponentModel.DataAnnotations;

namespace ExamenParcial2_Progra3.Models
    {
    public class CategoriaMeta
        {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Meta> Metas { get; set; } = new List<Meta>();
         }
    }
