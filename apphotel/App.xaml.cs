

using apphotel.Models;

namespace apphotel
{
    public partial class App : Application
    {
        // defini uma lista da Classe Quarto:
        public List<Quarto> quartos = new List<Quarto>
        {
            //criado os objetos quartos a partir da instancia da classe Quarto.
            new Quarto()
            {
                descricao = "SUÍTE SUPER LUXO",
                valorDiariaAdulto = 110,
                valorDiariaCrianca = 55
            },
            new Quarto()
            {
                descricao = "SUÍTE DE LUXO",
                valorDiariaAdulto = 80,
                valorDiariaCrianca = 40
            },
            new Quarto()
            {
                descricao = "SUÍTE DE SINGLE",
                valorDiariaAdulto = 50,
                valorDiariaCrianca = 25
            },
            new Quarto()
            {
                descricao = "SUÍTE DE POBRE",
                valorDiariaAdulto = 25,
                valorDiariaCrianca = 10
            }
        };

        public List<Cidades> cidades = new List<Cidades>
        {
            new Cidades("Paris", "França"),
            new Cidades("Londres", "Reino Unido"),
            new Cidades("Nova York", "Estados Unidos"),
            new Cidades("Tóquio", "Japão"),
            new Cidades("Berlim", "Alemanha"),
            new Cidades("Roma", "Itália"),
            new Cidades("Madri", "Espanha"),
            new Cidades("Lisboa", "Portugal"),
            new Cidades("Toronto", "Canadá"),
            new Cidades("Buenos Aires", "Argentina"),
            new Cidades("Cidade do México", "México"),
            new Cidades("Sydney", "Austrália"),
            new Cidades("Pequim", "China"),
            new Cidades("Seul", "Coreia do Sul"),
            new Cidades("Cidade do Cabo", "África do Sul"),
            new Cidades("Moscou", "Rússia"),
            new Cidades("Amsterdã", "Países Baixos"),
            new Cidades("Dubai", "Emirados Árabes Unidos"),
            new Cidades("Bangkok", "Tailândia"),
            new Cidades("Istambul", "Turquia")

        };
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.MainPage());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;

            return window;
        }
    }
}
