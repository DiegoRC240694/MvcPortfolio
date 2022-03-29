using System.ComponentModel.DataAnnotations;

namespace MvcPortfolio.Models
{
    public abstract class Entidade
    {
        public long Id { get; set; }
        public bool Active { get; set; }
    }

    public abstract class BaseEntidade : Entidade
    {
        [Display(Name = "Registro Data Hora")]
        public DateTime RegistroDataHora { get; set; }

        [Display(Name = "Alteracao Data Hora")]
        public DateTime AlteracaoDataHora { get; set; }
    }

}
