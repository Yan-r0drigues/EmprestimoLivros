using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Models
{
    public class LivroModel
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Autor { get; set; }
        public string Editora { get; set; }
        [Required]
        public DateTime DataPublicacao { get; set; }
        [Key]
        public int Id { get; set; }
        
        public ICollection<EmprestimosModel>? Emprestimos { get; set; }
    }
}
