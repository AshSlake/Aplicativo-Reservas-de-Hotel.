namespace apphotel.Models
{
    public class Cidades
    {
        private string nomeCidade { get; set; }
        private string pais { get; set; }
        public string cidadeFormatada => $"{nomeCidade}, {pais}";

        public Cidades(string nomeDaCidade, string nomepais)
        {
            nomeCidade = nomeDaCidade;
            pais = nomepais;
        }

    }
}
