namespace apphotel.Models
{
    public class Hospedagem
    {
        public Quarto quartoSelecioando { get; set; }
        public int quantidadeAdultos { get; set; }
        public int quantidadeCriancas { get; set; }
        public DateTime dataChekIn { get; set; }
        public DateTime dataCheckOut { get; set; }

        public Hospedagem()
        {

        }

        public Hospedagem(Quarto quartoSelecioando, int quantidadeAdultos, int quantidadeCriancas, DateTime dataChekIn, DateTime dataCheckOut)
        {
            //criando uma array de tuplas para validar os parametros recebidos no construtor.
            var parametros = new (object valor, string nome, string mensagemErro)[]
            {
                (quartoSelecioando, nameof(quartoSelecioando), "Quarto não selecionado."),
                (quantidadeAdultos, nameof(quantidadeAdultos), "Quantidade de adultos inválida."),
                (quantidadeCriancas, nameof(quantidadeCriancas), "Quantidade de crianças inválida."),
                (dataChekIn, nameof(dataChekIn), "Data de check-in inválida."),
                (dataCheckOut, nameof(dataCheckOut), "Data de check-out inválida.")
            };

            // Valida os parametros recebidos, verificando se são nulos ou inválidos.
            foreach (var (valor, nome, mensagemErro) in parametros)
            {
                if (valor is null ||
                    (valor is int i && i <= 0) ||
                    (valor is DateTime d && d == default))
                {
                    throw new ArgumentException(mensagemErro, nome);
                }
            }

            //veridica se a data de check-out é posterior à data de check-in.
            if (dataCheckOut <= dataChekIn)
            {
                throw new ArgumentException("Data de check-out deve ser posterior à data de check-in");
            }

            // Atribui os valores recebidos aos atributos da classe apos validação.
            this.quartoSelecioando = quartoSelecioando;
            this.quantidadeAdultos = quantidadeAdultos;
            this.quantidadeCriancas = quantidadeCriancas;
            this.dataChekIn = dataChekIn;
            this.dataCheckOut = dataCheckOut;
        }

        // Propriedade que retorna a quantidade de dias de estadia formatada como string.
        public String diasEstadia
        {
            get => quantidadeDiasEstadia.ToString() + " dias";
        }

        public int quantidadeDiasEstadia
        {
            get => dataCheckOut.Subtract(dataChekIn).Days;
        }

        // Propriedade que retorna a data de check-in formatada como string.
        public String dataformatadaChekIn
        {
            get => dataChekIn.ToString("dd/MM/yyyy");
        }

        // Propriedade que retorna a data de check-out formatada como string.
        public String dataformatadaCheckOut
        {
            get => dataCheckOut.ToString("dd/MM/yyyy");
        }



        public String valorTotalAcomodacao
        {
            get
            {
                //calculo da quantidade de adultos 
                double valor_adulto = quantidadeAdultos * quartoSelecioando.valorDiariaAdulto;

                //calcuco da quantidade de crianças 
                double valor_crianca = quantidadeCriancas * quartoSelecioando.valorDiariaCrianca;

                //calculo do total a ser pago durante a estadia total.
                double total = (valor_adulto + valor_crianca) * quantidadeDiasEstadia;

                // utilizando o método <variavel>.ToString("C", new CultureInfo("pt-BR"))
                // para converter a o total em valor monetario brasileiro.
                String totalFormatado = total.ToString("C", new System.Globalization.CultureInfo("pt-BR"));

                if (totalFormatado == null)
                {
                    throw new ArgumentException("Ops valores invalidos");
                }

                return totalFormatado;
            }
        }
    }
}
