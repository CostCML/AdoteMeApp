namespace AdoteMeApp.Views;

public partial class RecuperarSenhaPage : ContentPage
{
    public RecuperarSenhaPage()
    {
        InitializeComponent();
    }

    private async void OnEnviarClicked(
        object sender,
        EventArgs e)
    {
        await DisplayAlert(
            "Recuperação",
            "E-mail enviado.",
            "OK");
    }
}