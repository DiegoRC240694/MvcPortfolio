using System.ComponentModel.DataAnnotations;

namespace MvcPortfolio.Models
{
    public class Membros : Entidade
    {
        [Display(Name = "Pessoa")]
        public Pessoa? Pessoa { get; set; }

        [Display(Name = "Projeto")]
        public Projeto? Projeto { get; set; }
    }
}
