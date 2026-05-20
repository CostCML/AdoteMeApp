using AdoteMeApp.Services;

namespace AdoteMeApp.Views;

public partial class RecuperarSenhaPage : ContentPage
{
    private readonly DatabaseService _database;

    private readonly ValidationService _validation;

    private readonly CryptographyService _crypto;

    public RecuperarSenhaPage()
    {
        InitializeComponent();

        _database =
            MauiProgram.Current.Services
            .GetRequiredService<DatabaseService>();

        _validation =
            MauiProgram.Current.Services
            .GetRequiredService<ValidationService>();

        _crypto =
            MauiProgram.Current.Services
            .GetRequiredService<CryptographyService>();
    }

    private async void OnAtualizarSenhaClicked(
        object sender,
        EventArgs e)
    {
        if (!_validation.EmailValido(
            EmailEntry.Text ?? ""))
        {
            await DisplayAlert(
                "Erro",
                "Digite um e-mail válido.",
                "OK");

            return;
        }

        if (!_validation.SenhaForte(
            NovaSenhaEntry.Text ?? ""))
        {
            await DisplayAlert(
                "Erro",
                "A senha deve conter letra maiúscula, número e caractere especial.",
                "OK");

            return;
        }

        if (NovaSenhaEntry.Text !=
            ConfirmarSenhaEntry.Text)
        {
            await DisplayAlert(
                "Erro",
                "As senhas não coincidem.",
                "OK");

            return;
        }

        var usuario =
            await _database.BuscarPorEmail(
                EmailEntry.Text!);

        if (usuario == null)
        {
            await DisplayAlert(
                "Erro",
                "Usuário não encontrado.",
                "OK");

            return;
        }

        usuario.Senha =
            _crypto.GerarHash(
                NovaSenhaEntry.Text!);

        await _database.AtualizarUsuario(
            usuario);

        await DisplayAlert(
            "Sucesso",
            "Senha atualizada com sucesso.",
            "OK");

        await Navigation.PopAsync();
    }
}