

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

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ContratacaoHospedagem());
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
