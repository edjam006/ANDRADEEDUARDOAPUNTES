using ANDRADEEDUARDOAPUNTES.Models;
using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ANDRADEEDUARDOAPUNTES.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NotePage : ContentPage
    {
        // Nombre de archivo para la nota
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

        public NotePage()
        {
            InitializeComponent();

            string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
            string filePath = Path.Combine(FileSystem.AppDataDirectory, randomFileName);

            BindingContext = new Note
            {
                Filename = filePath,
                Date = DateTime.Now
            };
        }

        // Método para cargar la nota desde el archivo
        private void LoadNote(string filePath)
        {
            if (File.Exists(filePath))
            {
                // Si el archivo existe, cargar su contenido en el Editor
                TextEditor.Text = File.ReadAllText(filePath);
            }
        }

        // Método que se ejecuta al hacer clic en el botón "Save"
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Note note)
            {
                note.Text = TextEditor.Text;
                File.WriteAllText(note.Filename, note.Text);
            }

            await Shell.Current.GoToAsync("..");
        }

        // Método que se ejecuta al hacer clic en el botón "Delete"
        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.Note note)
            {
                // Eliminar el archivo de la nota
                if (File.Exists(note.Filename))
                {
                    File.Delete(note.Filename);
                }
            }

            // Navegar hacia atrás
            await Shell.Current.GoToAsync("..");
        }

        // Propiedad para manejar la navegación y carga de la nota usando ItemId
        public string ItemId
        {
            set
            {
                if (File.Exists(value))
                {
                    var noteText = File.ReadAllText(value);
                    BindingContext = new Note
                    {
                        Filename = value,
                        Text = noteText,
                        Date = File.GetCreationTime(value)
                    };
                }
            }
        }

    }
}
