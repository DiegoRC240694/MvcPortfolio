using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvcPortfolio.Models
{
    public class Pessoa : BaseEntidade
    {

        [Display(Name = "Primeiro Nome")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Campo Nome deve ser preenchido.")]
        [MaxLength(50, ErrorMessage = "Nome dever ter no maxímo 50 caracteres.")]
        public string? PrimeiroNome { get;  set; }

        [Display(Name = "Sobrenome")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Campo Sobrenome deve ser preenchido.")]
        [MaxLength(50, ErrorMessage = "Nome dever ter no maxímo 50 caracteres.")]
        public string? Sobrenome { get;  set; }

        [Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get;  set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo CPF deve ser preenchido.")]
        [MaxLength(11, ErrorMessage = "CPF dever ter no maxímo 11 caracteres.")]
        public string? Cpf { get;  set; }

        [Display(Name = "Nome Completo")]
        public string NomeCompleto =>
     $"{PrimeiroNome} {Sobrenome}";

        public int Idade
        {
            get
            {
                var dataAtual = DateTime.Now;
                var idade = dataAtual.Year - DataNascimento.Year;

                if (dataAtual.Month < DataNascimento.Month)
                {
                    idade--;
                }

                return idade;
            }
        }

       
        //public Pessoa(string primeiroNome, string ultimoNome, DateTime birthDate, Cpf cpf)
        //{
        //    PrimeiroNome = primeiroNome.Trim();
        //    Sobrenome = ultimoNome.Trim();

        //    if (DateTime.Now.Year - birthDate.Year > 110 || DateTime.Now.Year - birthDate.Year < 18)
        //    {
        //        throw new ExcecaoPortfolio("A idade deve ser maior que 18 e menor que 110!");
        //    }

        //    if (!cpf.EValido)
        //    {
        //        throw new ExcecaoPortfolio("Cpf Inválido!");
        //    }

        //    DataNascimento = birthDate;
        //    Cpf = cpf;
        //    RegistroDataHora = DateTime.Now;
        //    this.ValidateClasse();
        //}

        public bool ValidateClasse()
        {
            ValidationContext contexto = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> resultados = new List<ValidationResult>();
            bool Evalido = Validator.TryValidateObject(this, contexto, resultados, true);

            if (Evalido == false)
            {
                StringBuilder errosSbr = new StringBuilder();
                foreach (var resultadoValidacao in resultados)
                {
                    errosSbr.AppendLine(resultadoValidacao.ErrorMessage);
                }
                throw new ValidationException(errosSbr.ToString());
            }
            return true;
        }

    

        
    }
}
