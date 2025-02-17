using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace WPFnba.Views
{
    /// <summary>
    /// Interaction logic for PlayerFormWindow1.xaml
    /// </summary>
    public partial class PlayerFormWindow1 : Window
    {
        private PlayerController _playerController; // Instancia del controlador para gestionar la lógica de datos

        public PlayerFormWindow1(PlayerController playerController)
        {
            InitializeComponent(); // Se inicializan los componentes de la ventana

            // Asigna la instancia del controlador
            _playerController = playerController;
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
                List<string> newPlayerData = new List<string>
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
                bool success = _playerController.AddPlayer(newPlayerData);

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
