using AdoteMeApp.Models;
using AdoteMeApp.Services;

namespace AdoteMeApp.Views;

public partial class CadastroAdotantePage : ContentPage
{
    private readonly DatabaseService _database;

    private readonly ValidationService _validation;

    private readonly CryptographyService _crypto;

    public CadastroAdotantePage()
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

    private async void OnCadastrarClicked(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            NomeEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o nome.",
                "OK");

            return;
        }

        if (!_validation.CPFValido(
            CPFEntry.Text ?? ""))
        {
            await DisplayAlert(
                "Erro",
                "CPF inválido.",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(
            TelefoneEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o telefone.",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(
            EnderecoEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o endereço.",
                "OK");

            return;
        }

        if (!_validation.EmailValido(
            EmailEntry.Text ?? ""))
        {
            await DisplayAlert(
                "Erro",
                "E-mail inválido.",
                "OK");

            return;
        }

        if (!_validation.SenhaForte(
            SenhaEntry.Text ?? ""))
        {
            await DisplayAlert(
                "Erro",
                "A senha deve conter letras maiúsculas, minúsculas, números e caracteres especiais.",
                "OK");

            return;
        }

        if (SenhaEntry.Text !=
            ConfirmarSenhaEntry.Text)
        {
            await DisplayAlert(
                "Erro",
                "As senhas não coincidem.",
                "OK");

            return;
        }

        if (!TermosCheck.IsChecked)
        {
            await DisplayAlert(
                "Erro",
                "Aceite os termos de uso.",
                "OK");

            return;
        }

        var usuarioExistente =
            await _database.BuscarPorEmail(
                EmailEntry.Text!);

        if (usuarioExistente != null)
        {
            await DisplayAlert(
                "Erro",
                "E-mail já cadastrado.",
                "OK");

            return;
        }

        Usuario usuario = new()
        {
            Nome = NomeEntry.Text!,
            CPF = CPFEntry.Text!,
            DataNascimento = NascimentoPicker.Date,
            Telefone = TelefoneEntry.Text!,
            Endereco = EnderecoEntry.Text!,
            Cidade = CidadeEntry.Text!,
            Estado = EstadoEntry.Text!,
            CEP = CEPEntry.Text!,
            Email = EmailEntry.Text!,

            Senha =
                _crypto.GerarHash(
                    SenhaEntry.Text!),

            TipoUsuario = "Adotante"
        };

        await _database.SalvarUsuario(
            usuario);

        await DisplayAlert(
            "Sucesso",
            "Cadastro realizado com sucesso.",
            "OK");

        await Navigation.PopAsync();
    }
}