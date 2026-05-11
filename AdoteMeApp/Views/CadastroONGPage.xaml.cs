namespace AdoteMeApp.Views;

public partial class CadastroONGPage : ContentPage
{
    public CadastroONGPage()
    {
        InitializeComponent();
    }

    private async void OnCadastrarClicked(
        object sender,
        EventArgs e)
    {
        await DisplayAlert(
            "Sucesso",
            "ONG cadastrada com sucesso.",
            "OK");

        await Navigation.PopAsync();
    }
}