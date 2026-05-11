namespace AdoteMeApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnEntrarClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new DashboardPage());
    }

    private async void OnCadastroClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new CadastroAdotantePage());
    }

    private async void OnCadastroONGClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new CadastroONGPage());
    }

    private async void OnLoginParceiroClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new LoginParceiroPage());
    }

    private async void OnRecuperarSenhaClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new RecuperarSenhaPage());
    }
}