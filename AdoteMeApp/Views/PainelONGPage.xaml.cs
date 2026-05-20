using AdoteMeApp.Models;
using AdoteMeApp.Services;

namespace AdoteMeApp.Views;

public partial class PainelONGPage : ContentPage
{
    private readonly DatabaseService _database;

    private List<SolicitacaoAdocao>
        _solicitacoes = new();

    public PainelONGPage()
    {
        InitializeComponent();

        _database =
            MauiProgram.Current.Services
            .GetRequiredService<DatabaseService>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _solicitacoes =
            await _database
            .ListarSolicitacoes();

        SolicitacoesCollection.ItemsSource =
            _solicitacoes;
    }

    private async void OnAprovarClicked(
        object sender,
        EventArgs e)
    {
        Button botao =
            (Button)sender;

        SolicitacaoAdocao solicitacao =
            (SolicitacaoAdocao)
            botao.CommandParameter;

        solicitacao.Status =
            "Aprovado";

        await _database
            .AtualizarSolicitacao(
                solicitacao);

        SolicitacoesCollection.ItemsSource =
            null;

        SolicitacoesCollection.ItemsSource =
            _solicitacoes;

        await DisplayAlert(
            "Sucesso",
            "Solicitação aprovada.",
            "OK");
    }

    private async void OnRecusarClicked(
        object sender,
        EventArgs e)
    {
        Button botao =
            (Button)sender;

        SolicitacaoAdocao solicitacao =
            (SolicitacaoAdocao)
            botao.CommandParameter;

        solicitacao.Status =
            "Recusado";

        await _database
            .AtualizarSolicitacao(
                solicitacao);

        SolicitacoesCollection.ItemsSource =
            null;

        SolicitacoesCollection.ItemsSource =
            _solicitacoes;

        await DisplayAlert(
            "Sucesso",
            "Solicitação recusada.",
            "OK");
    }
}