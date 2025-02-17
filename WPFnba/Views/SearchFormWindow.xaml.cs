using System;
using System.Windows;
using WPFnba.View;

// Examen 3

namespace WPFnba.Views
{
    /// <summary>
    /// Interaction logic for SearchFormWindow.xaml
    /// </summary>
    public partial class SearchFormWindow : Window
    {
        private PlayerController _playerController; // Instancia del controlador para gestionar la lógica de datos
        private MainWindow _mainWindow; // Referencia a la ventana principal

        public SearchFormWindow(PlayerController playerController, MainWindow mainWindow)
        {
            InitializeComponent(); // Se inicializan los componentes de la ventana

            // Asigna la instancia del controlador
            _playerController = playerController;
            _mainWindow = mainWindow; // Asigna la referencia a la ventana principal
        }

        private void Search_Event(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchPlayerData = PlayerLastName_tbox.Text.Trim(); // Apellido del jugador

                // Llama al método del controlador para actualizar los datos en la base de datos
                int id = _playerController.GetPlayerByLastName(searchPlayerData);

                if (id != -1) // Verifica si ocurrió un error en la actualización
                {
                    this.Close(); // Cierra la ventana después de la actualización
                    _mainWindow.LoadPlayerData(id); // Carga los datos del jugador en la ventana de edición
                }
                else
                {
                    MessageBox.Show("Can not find player.");
                    this.Close(); // Cierra la ventana después de la actualización
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while procesing data: {ex.Message}");
            }
        }

        private void Cancel_Event(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana sin realizar ninguna modificación
        }
    }
}
