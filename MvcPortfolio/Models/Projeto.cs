using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;
using System.Runtime;

namespace MvcPortfolio.Models
{
    public enum ProjetoStatus
    {
        EmAnalise,
        AnaliseRealizada,
        AnaliseAprovada,
        Iniciado,
        Planejado,
        EmAndamento,
        Encerrado,
        Cancelado

    }

    public enum ProjetoRisco
    {
        BaixoRisco,
        MedioRisco,
        AltoRisco
    }

    public class Projeto : BaseEntidade
    {
        //public Projeto(string? nome, DateTime dataInicio, DateTime dataPrevisaoFim, DateTime dataFim, string? descricao, ProjetoStatus status, float orcamento)
        //{
        //    if (dataInicio < DateTime.Now)
        //    {
        //        throw new ExcecaoPortfolio("A data de inicio nao pode ser menor que a data atual");
        //    }

        //    if (dataPrevisaoFim < DateTime.Now && dataPrevisaoFim < dataInicio)
        //    {
        //        throw new ExcecaoPortfolio("A data previsao fim nao pode ser menor que a data atual e data inicio");
        //    }

        //    if(dataFim < DateTime.Now && dataFim < dataPrevisaoFim)
        //    {
        //        throw new ExcecaoPortfolio("A data fim nao pode ser menor que a data atual, data inicio e data previsao fim");
        //    }

        //    if (orcamento < 0) throw new ExcecaoPortfolio("O orcamneto deve ser maior que 0");

        //   // status = ProjetoStatus.EmAnalise;

        //    Nome = nome;
        //    DataInicio = dataInicio;
        //    DataPrevisaoFim = dataPrevisaoFim;
        //    DataFim = dataFim;
        //    Descricao = descricao;
        //    Status = status;
        //    Orcamento = orcamento;
        //    RegistroDataHora = DateTime.Now;
        //}

        [Display(Name = "Nome do Projeto")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Campo Nome do projeto deve ser preenchido.")]
        [MaxLength(50, ErrorMessage = "Nome do projeto dever ter no maxímo 50 caracteres.")]
        public string? Nome { get;  set; }

        [Display(Name = "Data inicio"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get;  set; }

        [Display(Name = "Data previsao fim"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataPrevisaoFim { get;  set; }

        [Display(Name = "Data previsao fim"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get;  set; }

        [Display(Name = "Descrição do Projeto")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Campo descrição do Projeto deve ser preenchido.")]
        [MaxLength(50, ErrorMessage = "Descrição do Projeto ter no maxímo 50 caracteres.")]
        public string? Descricao { get;  set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O status é obrigatório")]
        public ProjetoStatus Status { get;  set; }

        [Display(Name = "Orcamento")]
        [Range(1, 100), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Orcamento { get;  set; }


        [Display(Name = "Risco")]
        [Required(ErrorMessage = "O risco é obrigatório")]
        public ProjetoRisco Risco { get;  set; }

        

        public bool ValidateClasse()
        {
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid == false)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                throw new ValidationException(sbrErrors.ToString());
            }
            return true;
        }

       

    }
}
