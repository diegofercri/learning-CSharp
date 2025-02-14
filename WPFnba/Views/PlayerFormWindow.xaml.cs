using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace WPFnba.View
{
    /// <summary>
    /// Interaction logic for PlayerFormWindow.xaml
    /// </summary>
    public partial class PlayerFormWindow : Window
    {
        private PlayerController _playerController; // Instancia del controlador para gestionar la lógica de datos
        private DataRow playerRow; // Almacena la fila del equipo seleccionado para su actualización

        public PlayerFormWindow(PlayerController playerController, DataTable playerData)
        {
            InitializeComponent(); // Se inicializan los componentes de la ventana

            if (playerData == null || playerData.Rows.Count == 0)
            {
                MessageBox.Show("No se proporcionaron datos válidos para el jugador.");
                this.Close(); // Cierra la ventana si no hay datos válidos
                return;
            }

            // Asigna la instancia del controlador
            _playerController = playerController;

            // Obtiene la primera fila del DataTable (asumimos que solo hay un equipo)
            playerRow = playerData.Rows[0];

            // Carga los datos del equipo en los campos de la interfaz
            this.PlayerPhoto_tbox.Text = playerRow["headShotUrl"]?.ToString() ?? string.Empty; // URL de la foto del jugador
            this.PlayerFirstName_tbox.Text = playerRow["firstName"]?.ToString() ?? string.Empty; // Nombre del jugador
            this.PlayerLastName_tbox.Text = playerRow["lastName"]?.ToString() ?? string.Empty; // Número del jugador
            this.PlayerTeam_tbox.Text = playerRow["team"]?.ToString() ?? string.Empty; // Equipo del jugador
            this.PlayerPosition_tbox.Text = playerRow["position"]?.ToString() ?? string.Empty; // Posición del jugador
            this.PlayerJerseyNumber_tbox.Text = playerRow["jerseyNumber"]?.ToString() ?? string.Empty; // Número del jugador
            this.PlayerAge_tbox.Text = playerRow["age"]?.ToString() ?? string.Empty; // Edad del jugador
            this.PlayerDateOfBirth_tbox.Text = playerRow["dateOfBirth"]?.ToString() ?? string.Empty; // Fecha de nacimiento del jugador
            this.PlayerHeight_tbox.Text = playerRow["height"]?.ToString() ?? string.Empty; // Altura del jugador
            this.PlayerWeight_tbox.Text = playerRow["weight"]?.ToString() ?? string.Empty; // Peso del jugador
            this.PlayerPoints_tbox.Text = playerRow["careerPoints"]?.ToString() ?? string.Empty; // Puntos en la carrera del jugador
            this.PlayerBlocks_tbox.Text = playerRow["careerBlocks"]?.ToString() ?? string.Empty; // Bloqueos en la carrera del jugador
            this.PlayerAssists_tbox.Text = playerRow["careerAssists"]?.ToString() ?? string.Empty; // Asistencias en la carrera del jugador
            this.PlayerRebounds_tbox.Text = playerRow["careerRebounds"]?.ToString() ?? string.Empty; // Rebotes en la carrera del jugador
            this.PlayerTurnovers_tbox.Text = playerRow["careerTurnovers"]?.ToString() ?? string.Empty; // Pérdidas en la carrera del jugador
            this.PlayerThree_tbox.Text = playerRow["careerPercentageThree"]?.ToString() ?? string.Empty; // Porcentaje de triples en la carrera del jugador
            this.PlayerFreethrow_tbox.Text = playerRow["careerPercentageFreethrow"]?.ToString() ?? string.Empty; // Porcentaje de tiros libres en la carrera del jugador
            this.PlayerFieldGoal_tbox.Text = playerRow["careerPercentageFieldGoal"]?.ToString() ?? string.Empty; // Porcentaje de tiros de campo en la carrera del jugador

        }

        private void Save_Event(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are going to modify a registry. Are you sure?"); // Mensaje de confirmación

            if (playerRow == null)
            {
                MessageBox.Show("Los datos del jugador no están disponibles.");
                return;
            }

            try
            {
                // Extraer el ID y la última hora de modificación del DataTable
                int id = Convert.ToInt32(playerRow["id"]); // ID del equipo
                string dateLastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Fecha y hora actual

                // Crear una lista con los datos actualizados
                List<string> updatedPlayerData = new List<string>
                {
                    id.ToString(), // ID del jugador
                    PlayerFirstName_tbox.Text.Trim(), // Nombre del jugador
                    PlayerLastName_tbox.Text.Trim(), // Apellido del jugador
                    PlayerTeam_tbox.Text.Trim(), // Equipo del jugador
                    PlayerPosition_tbox.Text.Trim(), // Posición del jugador
                    PlayerDateOfBirth_tbox.Text.Trim(), // Fecha de nacimiento del jugador
                    PlayerHeight_tbox.Text.Trim(), // Altura del jugador
                    PlayerWeight_tbox.Text.Trim(), // Peso del jugador
                    PlayerJerseyNumber_tbox.Text.Trim(), // Número del jugador
                    PlayerAge_tbox.Text.Trim(), // Edad del jugador
                    PlayerPoints_tbox.Text.Trim(), // Puntos en la carrera del jugador
                    PlayerBlocks_tbox.Text.Trim(), // Bloqueos en la carrera del jugador
                    PlayerAssists_tbox.Text.Trim(), // Asistencias en la carrera del jugador
                    PlayerRebounds_tbox.Text.Trim(), // Rebotes en la carrera del jugador
                    PlayerTurnovers_tbox.Text.Trim(), // Pérdidas en la carrera del jugador
                    PlayerThree_tbox.Text.Trim(), // Porcentaje de triples en la carrera del jugador
                    PlayerFreethrow_tbox.Text.Trim(), // Porcentaje de tiros libres en la carrera del jugador
                    PlayerFieldGoal_tbox.Text.Trim(), // Porcentaje de tiros de campo en la carrera del jugador
                    PlayerPhoto_tbox.Text.Trim(), // URL de la foto del jugador
                    dateLastUpdated // Última hora de modificación
                };

                // Llama al método del controlador para actualizar los datos en la base de datos
                bool success = _playerController.UpdatePlayer(updatedPlayerData);

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
