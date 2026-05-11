namespace AdoteMeApp.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    private async void OnBuscarONGsClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new BuscarONGsPage());
    }

    private async void OnAnimaisClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new AnimaisPage());
    }
}