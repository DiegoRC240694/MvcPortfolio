namespace MvcPortfolio.Models
{
    public struct Cpf
    {
        readonly string _valor;
        readonly string _somenteDigitosCpf;
        public readonly bool EValido;

        public Cpf(string valor)
        {
            _valor = valor;
            _somenteDigitosCpf = string.Empty;

            if (valor == null)
            {
                EValido = false;
                return;
            }

            var posicao = 0;
            var digitoTotal1 = 0;
            var digitoTotal2 = 0;
            var dv1 = 0;
            var dv2 = 0;

            bool mesmosDigitos = true;
            var ultimoDigito = -1;

            foreach (var c in valor)
            {
                if (char.IsDigit(c))
                {
                    _somenteDigitosCpf += c;

                    var digito = c - '0';
                    if (posicao != 0 && ultimoDigito != digito)
                    {
                        mesmosDigitos = false;
                    }

                    ultimoDigito = digito;
                    if (posicao < 9)
                    {
                        digitoTotal1 += digito * (10 - posicao);
                        digitoTotal2 += digito * (11 - posicao);
                    }
                    else if (posicao == 9)
                    {
                        dv1 = digito;
                    }
                    else if (posicao == 10)
                    {
                        dv2 = digito;
                    }

                    posicao++;
                }
            }

            if (posicao > 11)
            {
                EValido = false;
                return;
            }

            if (mesmosDigitos)
            {
                EValido = false;
                return;
            }

            var digito1 = digitoTotal1 % 11;
            digito1 = digito1 < 2
                ? 0
                : 11 - digito1;

            if (dv1 != digito1)
            {
                EValido = false;
                return;
            }

            digitoTotal2 += digito1 * 2;
            var digito2 = digitoTotal2 % 11;
            digito2 = digito2 < 2
                ? 0
                : 11 - digito2;

            EValido = dv2 == digito2;
        }

        public static implicit operator Cpf(string valor)
            => new Cpf(valor);

        public override string ToString() => _valor;

        public string CpfFormatado =>
            Convert.ToUInt64(_somenteDigitosCpf).ToString(@"000\.000\.000\-00");
    }
}
