using ANDRADEEDUARDOAPUNTES.Models;

namespace ANDRADEEDUARDOAPUNTES.Views;

public partial class AllNotesPage : ContentPage
{
    AllNotes viewModel;
    public AllNotesPage()
    {
        InitializeComponent();
        viewModel = new AllNotes();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        viewModel.LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        var note = (Note)e.CurrentSelection[0];
        await Shell.Current.GoToAsync($"{nameof(NotePage)}?ItemId={note.Filename}");

        notesCollection.SelectedItem = null;
    }
}
