namespace AdoteMeApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnCadastroAdotanteClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroAdotantePage());
    }

    private async void OnSolicitarParceriaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SolicitacaoParceiroPage());
    }

    private async void OnLoginParceiroClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginParceiroPage());
    }

    private async void OnLoginAdminClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginAdminPage());
    }
}