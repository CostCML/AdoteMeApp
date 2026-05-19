using AdoteMeApp.Models;
using AdoteMeApp.Services;

namespace AdoteMeApp.Views;

public partial class CadastroAnimalPage : ContentPage
{
    private readonly DatabaseService _database;

    private string _fotoPath = "";

    public CadastroAnimalPage()
    {
        InitializeComponent();

        _database =
            MauiProgram.Current.Services
            .GetRequiredService<DatabaseService>();
    }


    private async void OnSelecionarFotoClicked(
        object sender,
        EventArgs e)
        {
            try
            {
                FileResult? foto =
                    await MediaPicker.PickPhotoAsync();

                if (foto == null)
                    return;

                _fotoPath = foto.FullPath;

                FotoAnimal.Source =
                    ImageSource.FromFile(
                        _fotoPath);
            }
            catch
            {
                await DisplayAlert(
                    "Erro",
                    "Não foi possível selecionar a foto.",
                    "OK");
        }
    }

    private async void OnCadastrarAnimalClicked(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            NomeEntry.Text))
        {
            await DisplayAlert(
                "Erro",
                "Digite o nome do animal.",
                "OK");

            return;
        }

        if (EspeciePicker.SelectedIndex == -1)
        {
            await DisplayAlert(
                "Erro",
                "Selecione a espécie.",
                "OK");

            return;
        }

        if (SexoPicker.SelectedIndex == -1)
        {
            await DisplayAlert(
                "Erro",
                "Selecione o sexo.",
                "OK");

            return;
        }

        if (PortePicker.SelectedIndex == -1)
        {
            await DisplayAlert(
                "Erro",
                "Selecione o porte.",
                "OK");

            return;
        }

        Animal animal = new()
        {
            Nome = NomeEntry.Text!,
            Especie =
                EspeciePicker.SelectedItem.ToString()!,
            Raca = RacaEntry.Text ?? "",
            Idade = IdadeEntry.Text ?? "",

            Sexo =
                SexoPicker.SelectedItem.ToString()!,

            Porte =
                PortePicker.SelectedItem.ToString()!,

            Vacinado =
                VacinadoCheck.IsChecked,

            Castrado =
                CastradoCheck.IsChecked,

            Descricao =
                DescricaoEditor.Text ?? "",

            StatusAdocao = "Disponível",

            FotoPath = _fotoPath
        };

        await _database.SalvarAnimal(
            animal);

        await DisplayAlert(
            "Sucesso",
            "Animal cadastrado.",
            "OK");

        await Navigation.PopAsync();
    }
}