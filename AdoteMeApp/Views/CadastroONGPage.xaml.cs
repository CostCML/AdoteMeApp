using AdoteMeApp.Validators;

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
        if (string.IsNullOrWhiteSpace(NomeONGEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o nome da ONG.",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(ResponsavelEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o responsável.",
                "OK");

            return;
        }

        if (!CNPJValidator.Validar(CNPJEntry.Text ?? ""))
        {
            await DisplayAlert(
                "Erro",
                "CNPJ inválido.",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(TelefoneEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o telefone.",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(EnderecoEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o endereço.",
                "OK");

            return;
        }

        if (!EmailValidator.Validar(EmailEntry.Text ?? ""))
        {
            await DisplayAlert(
                "Erro",
                "E-mail inválido.",
                "OK");

            return;
        }

        if (!SenhaValidator.Validar(SenhaEntry.Text ?? ""))
        {
            await DisplayAlert(
                "Erro",
                "Senha fraca.",
                "OK");

            return;
        }

        await DisplayAlert(
            "Sucesso",
            "ONG cadastrada com sucesso.",
            "OK");

        await Navigation.PopAsync();
    }
}