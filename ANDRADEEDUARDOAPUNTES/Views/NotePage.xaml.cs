using ANDRADEEDUARDOAPUNTES.Models;  // Asegúrate de importar el modelo de Note
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

            string appDataPath = FileSystem.AppDataDirectory;
            string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

            LoadNote(Path.Combine(appDataPath, randomFileName));  // Cargar la nota al inicializar
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
            if (BindingContext is Models.Note note)
            {
                // Guardar el contenido de la nota en el archivo
                File.WriteAllText(note.Filename, TextEditor.Text);
            }

            // Navegar hacia atrás
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
            set { LoadNote(value); }
        }
    }
}
