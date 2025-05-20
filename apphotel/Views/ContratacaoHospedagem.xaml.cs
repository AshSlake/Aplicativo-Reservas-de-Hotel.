namespace apphotel.Views;

// classe parcial que representa a pagina de contratação de hospedagem da aplicação.
public partial class ContratacaoHospedagem : ContentPage
{
    // referencia á instância principal do aplicativo, para acessar propriedades globais
    App propriedadesDoApp;

    public ContratacaoHospedagem()
	{
        //inicia os componentes visuais do XAML.
        InitializeComponent();

        if (Application.Current == null) //Verifica se a instancia da aplicação atual é nula.
        {
            throw new Exception("Erro Aplicação nula");
        }

        //obtem a instância atual da aplicação e faz um cast para a classe do App.
        propriedadesDoApp = (App)Application.Current;


        pck_quarto.ItemsSource = propriedadesDoApp.quartos;// Pega a lista de quartos do picker contido na instancia da aplicação

        // defini a data minima do datePicker
        dtpck_checkIn.MinimumDate = DateTime.Now;
        // defini a data maxima do datePicker
        dtpck_checkIn.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        // Define a data mínima de check-out como um dia após o check-in selecionado
        dtpck_checkOut.MinimumDate = dtpck_checkIn.Date.AddDays(1);
        // Define a data máxima de check-out como até 6 meses após o check-in
        dtpck_checkOut.MaximumDate = dtpck_checkIn.Date.AddMonths(6);
    }

    private void Button_Clicked(object sender, EventArgs e)
        //logica do botão avançar da View de contratação.
    {
        try
            {
            Navigation.PushAsync(new HospedagemContratada());
        } catch (Exception ex)
        {

            DisplayAlert("OPS", ex.Message, "OK");
        }
    }

    private void dtpck_checkIn_DateSelected(object sender, DateChangedEventArgs e)
    // Listenner para a data_CheckIN.
    // ele altera o minimumDate e maximumDate baseado nas escolha do data_CheckIN.
    {
        DatePicker elemento = sender as DatePicker;
        DateTime data_selecionada = elemento.Date;

        dtpck_checkOut.MinimumDate = data_selecionada.AddDays(1);
        dtpck_checkOut.MaximumDate = data_selecionada.AddMonths(6);

    }
}