using AdoteMeApp.Models;
using AdoteMeApp.Services;

namespace AdoteMeApp.Views;

public partial class SolicitarAdocaoPage : ContentPage
{
    private readonly DatabaseService _database;

    private readonly Animal _animal;

    public SolicitarAdocaoPage(
        Animal animal)
    {
        InitializeComponent();

        _animal = animal;

        AnimalLabel.Text =
            $"Adotar {_animal.Nome}";

        _database =
            MauiProgram.Current.Services
            .GetRequiredService<DatabaseService>();
    }

    private async void OnEnviarClicked(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            NomeEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite seu nome.",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(
            EmailEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o e-mail.",
                "OK");

            return;
        }

        SolicitacaoAdocao solicitacao =
            new()
            {
                NomeAnimal = _animal.Nome,

                NomeAdotante =
                    NomeEntry.Text,

                EmailAdotante =
                    EmailEntry.Text,

                Telefone =
                    TelefoneEntry.Text ?? "",

                Mensagem =
                    MensagemEditor.Text ?? "",

                DataSolicitacao =
                    DateTime.Now
            };

        await _database
            .SalvarSolicitacao(
                solicitacao);

        await DisplayAlert(
            "Sucesso",
            "Solicitação enviada.",
            "OK");

        await Navigation.PopAsync();
    }
}