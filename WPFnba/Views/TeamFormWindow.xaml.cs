using System.Collections.Generic;
using System;
using System.Data;
using System.Windows;

namespace WPFnba.View
{
    /// <summary>
    /// Interaction logic for TeamFormWindow.xaml
    /// </summary>
    public partial class TeamFormWindow : Window
    {
        private TeamController _teamController; // Instancia del controlador para gestionar la lógica de datos
        private DataRow teamRow; // Almacena la fila del equipo seleccionado para su actualización

        public TeamFormWindow(TeamController teamController, DataTable teamData)
        {
            InitializeComponent(); // Se inicializan los componentes de la ventana

            if (teamData == null || teamData.Rows.Count == 0)
            {
                MessageBox.Show("No se proporcionaron datos válidos para el equipo.");
                this.Close(); // Cierra la ventana si no hay datos válidos
                return;
            }

            // Asigna la instancia del controlador
            _teamController = teamController;

            // Obtiene la primera fila del DataTable (asumimos que solo hay un equipo)
            teamRow = teamData.Rows[0];

            // Carga los datos del equipo en los campos de la interfaz
            this.TeamLogo_tbox.Text = teamRow["teamLogoUrl"]?.ToString() ?? string.Empty; // URL del logo del equipo
            this.TeamName_tbox.Text = teamRow["name"]?.ToString() ?? string.Empty; // Nombre del equipo
            this.TeamConference_tbox.Text = teamRow["conference"]?.ToString() ?? string.Empty; // Conferencia del equipo
            this.TeamRecord_tbox.Text = teamRow["record"]?.ToString() ?? string.Empty; // Récord del equipo
        }

        private void Save_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are going to modify a registry. Are you sure?"); // Mensaje de confirmación

            if (teamRow == null)
            {
                MessageBox.Show("Los datos del equipo no están disponibles.");
                return;
            }

            try
            {
                // Extraer el ID y la última hora de modificación del DataTable
                int id = Convert.ToInt32(teamRow["id"]); // ID del equipo
                string dateLastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Fecha y hora actual

                // Crear una lista con los datos actualizados
                List<string> updatedTeamData = new List<string>
                {
                    id.ToString(), // ID del equipo
                    TeamName_tbox.Text.Trim(), // Nombre del equipo
                    TeamConference_tbox.Text.Trim(), // Conferencia del equipo
                    TeamRecord_tbox.Text.Trim(), // Récord del equipo
                    TeamLogo_tbox.Text.Trim(), // URL del logo del equipo
                    dateLastUpdated // Última hora de modificación
                };

                // Llama al método del controlador para actualizar los datos en la base de datos
                bool success = _teamController.UpdateTeam(updatedTeamData);

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
