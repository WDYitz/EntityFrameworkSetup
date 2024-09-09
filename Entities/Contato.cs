using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ModuloAPI.Entities
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public bool Ativo { get; set; }

    }
}