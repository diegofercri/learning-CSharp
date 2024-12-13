using SafariApp_v2.Model;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace SafariApp_v2.Controller
{
    /// <summary>
    /// Controller responsible for managing the safari simulation, interacting with the Safari model,
    /// and updating the views when the model changes.
    /// </summary>
    internal class SafariController
    {
        // Variables
        private Safari safari;
        private CancellationTokenSource cancellationTokenSource; // To cancel the auto-play task
        private Task autoPlayTask; // Task running the auto-play process in the background

        public event Action ModelUpdated; // Event to notify views when the model has been updated

        // Constructor
        /// <summary>
        /// Initializes a new instance of the SafariController with the given safari model.
        /// </summary>
        /// <param name="safari">The Safari model that the controller will manage.</param>
        public SafariController(Safari safari)
        {
            this.safari = safari;
        }

        // Getters
        public string[,] getBeings() => safari.GetBeingsToString();
        public int GetNumPlantsAlive() => safari.GetNumPlantsAlive();
        public int GetNumGazellesAlive() => safari.GetNumGazellesAlive();
        /* Examen 1 */
        public int GetNumElephantsAlive() => safari.GetNumElephantsAlive();
        public int GetNumLionsAlive() => safari.GetNumLionsAlive();
        public int GetTurn() => safari.GetTurn();

        ///<summary>
        /// Starts the auto-play process by invoking Safari's AutoPlay method on a separate thread.
        /// </summary>
        public void playSafari()
        {
            cancellationTokenSource = new CancellationTokenSource(); // Initialize the cancellation token
            autoPlayTask = Task.Run(async () =>
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    safari.PlayTurn(); // Call the PlayTurn
                    ModelUpdated?.Invoke(); // Notify views that the model has been updated
                    await Task.Delay(1000); // Wait 1 second between turns
                }
            }, cancellationTokenSource.Token);
        }

        ///<summary>
        /// Stops the auto-play process by cancelling the token.
        /// </summary>
        public void stopSafari()
        {
            cancellationTokenSource?.Cancel(); // Request cancellation of the auto-play task
        }

        ///<summary>
        /// Plays one turn by invoking Safari's PlayTurn method.
        /// </summary>
        public void stepSafari()
        {
            safari.PlayTurn(); // Perform one step of the simulation (one turn)
            ModelUpdated?.Invoke(); // Notify views that the model has been updated
        }

        ///<summary>
        /// Resets Safari by invoking Safari's Reset method.
        /// </summary>
        public void resetSafari()
        {
            safari.Reset(); // Reset the safari simulation state in the model
            ModelUpdated?.Invoke(); // Notify views that the model has been reset
        }
    }
}
