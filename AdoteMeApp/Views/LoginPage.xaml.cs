using AdoteMeApp;
using AdoteMeApp.Services;

namespace AdoteMeApp.Views;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;

    private readonly CryptographyService _crypto;

    public LoginPage()
    {
        InitializeComponent();

        _authService =
            MauiProgram.Current.Services
            .GetRequiredService<AuthService>();

        _crypto =
            MauiProgram.Current.Services
            .GetRequiredService<CryptographyService>();
    }

    private async void OnEntrarClicked(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            EmailEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o e-mail.",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(
            SenhaEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite a senha.",
                "OK");

            return;
        }

        string senhaHash =
            _crypto.GerarHash(
                SenhaEntry.Text!);

        var usuario =
            await _authService.Login(
                EmailEntry.Text!,
                senhaHash);

        if (usuario == null)
        {
            await DisplayAlert(
                "Erro",
                "E-mail ou senha inválidos.",
                "OK");

            return;
        }

        await DisplayAlert(
            "Sucesso",
            $"Bem-vindo {usuario.Nome}",
            "OK");

        if (usuario.TipoUsuario == "ONG")
        {
            Application.Current.MainPage =
            new AdoteMeApp.AppShell();
        }
        else
        {
            await Navigation.PushAsync(
                new BuscarONGsPage());
        }
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
        await DisplayAlert(
            "Recuperação de senha",
            "Funcionalidade em desenvolvimento.",
            "OK");
    }
}