namespace apphotel.Views;

public partial class MainPage : ContentPage
{
    App propriedadesDoApp;
    private DateTime dataSelecionada; //variavel para ser passada para a ContratacaoHospedagem.

    public MainPage()
    {
        InitializeComponent();

        if (Application.Current == null) //Verifica se a instancia da aplicação atual é nula.
        {
            throw new Exception("Erro Aplicação nula");
        }

        propriedadesDoApp = (App)Application.Current;

        picker_cidade.ItemsSource = propriedadesDoApp.cidades;

        // defini a data minima do datePicker
        dtpck_checkIn.MinimumDate = DateTime.Now;
        // defini a data maxima do datePicker
        dtpck_checkIn.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        // event handler para atualizar a variavel dataSelecionada sempre que a data for atualizada.
        dtpck_checkIn.DateSelected += (s, e) =>
        {
            dataSelecionada = e.NewDate;
        };


    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        try
        {
            // navegando para ContratacaoHospedagem com a data da viagem
            Navigation.PushAsync(new ContratacaoHospedagem(dataSelecionada));
        }
        catch (Exception ex)
        {

            DisplayAlert("OPS", ex.Message, "OK");
        }

    }
}