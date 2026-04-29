using AdoteMeApp.Controllers;
using AdoteMeApp.Infrastructure;

namespace AdoteMeApp.Views;

public partial class AnimaisPage : ContentPage
{
    public AnimaisPage()
    {
        InitializeComponent();

        var controller = ServiceHelper.GetRequiredService<OngController>();
        BindingContext = controller.GetAnimals();
    }
}