namespace AdoteMeApp.Views;

public partial class CadastroAdotantePage : ContentPage
{
    public CadastroAdotantePage()
    {
        InitializeComponent();
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NomeEntry.Text))
        {
            await DisplayAlert("Atenção", "Informe o nome completo.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(CpfEntry.Text))
        {
            await DisplayAlert("Atenção", "Informe o CPF.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Atenção", "Informe o e-mail.", "OK");
            return;
        }

        if (!EmailEntry.Text.Contains("@"))
        {
            await DisplayAlert("Atenção", "E-mail inválido.", "OK");
            return;
        }

        if (SenhaEntry.Text != ConfirmarSenhaEntry.Text)
        {
            await DisplayAlert("Atenção", "As senhas não coincidem.", "OK");
            return;
        }

        if (SenhaEntry.Text.Length < 6)
        {
            await DisplayAlert("Atenção", "Senha deve ter no mínimo 6 caracteres.", "OK");
            return;
        }

        await DisplayAlert("Sucesso", "Cadastro realizado com sucesso.", "OK");

        await Navigation.PopAsync();
    }
}