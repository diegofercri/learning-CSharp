using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace WPFnba.Views
{
    /// <summary>
    /// Interaction logic for TeamFormWindow1.xaml
    /// </summary>
    public partial class TeamFormWindow1 : Window
    {
        private TeamController _teamController; // Instancia del controlador para gestionar la lógica de datos

        public TeamFormWindow1(TeamController teamController)
        {
            InitializeComponent(); // Se inicializan los componentes de la ventana

            // Asigna la instancia del controlador
            _teamController = teamController;
        }

        private void Save_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are going to add a registry. Are you sure?"); // Mensaje de confirmación

            try
            {
                // Extraer el ID y la última hora de modificación del DataTable
                int id = 0; // ID del equipo
                string dateLastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Fecha y hora actual

                // Crear una lista con los datos actualizados
                List<string> newTeamData = new List<string>
                {
                    id.ToString(), // ID del equipo
                    TeamName_tbox.Text.Trim(), // Nombre del equipo
                    TeamConference_tbox.Text.Trim(), // Conferencia del equipo
                    TeamRecord_tbox.Text.Trim(), // Récord del equipo
                    TeamLogo_tbox.Text.Trim(), // URL del logo del equipo
                    dateLastUpdated // Última hora de modificación
                };

                // Llama al método del controlador para actualizar los datos en la base de datos
                bool success = _teamController.AddTeam(newTeamData);

                if (success) // Verifica si ocurrió un error en la actualización
                {
                    MessageBox.Show("La actualización se ha realizado correctamente.");
                    this.Close(); // Cierra la ventana después de la actualización
                }
                else
                {
                    MessageBox.Show("Ha sucedido un error en la actualización.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar los datos: {ex.Message}");
            }
        }

        private void Cancel_Event(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana sin realizar ninguna modificación
        }
    }
}
