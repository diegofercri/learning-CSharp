using SafariApp_v2.Model;
using System.Threading.Tasks;
using System.Threading;

namespace SafariApp_v2.Controller
{
    internal class Controller
    {
        private Safari safari;
        private CancellationTokenSource cancellationTokenSource; // To cancel the auto-play
        private Task autoPlayTask; // Task that runs AutoPlay in the background

        public Controller(Safari safari)
        {
            this.safari = safari;
        }

        public Being[,] getBeings()
        {
            return safari.GetBeings();
        }

        ///<summary>
        /// Starts the auto-play process by invoking Safari's AutoPlay method on a separate thread.
        /// </summary>
        public void playSafari()
        {
            // Create a new CancellationTokenSource to manage cancellation
            cancellationTokenSource = new CancellationTokenSource();

            // Run the AutoPlay method in the background
            autoPlayTask = Task.Run(() => safari.AutoPlay(cancellationTokenSource.Token));
        }

        ///<summary>
        /// Stops the auto-play process by cancelling the token.
        /// </summary>
        public void stopSafari()
        {
            // Cancel the auto-play task
            cancellationTokenSource?.Cancel();
        }

        ///<summary>
        /// Plays one turn by invoking Safari's PlayTurn method.
        /// </summary>
        public void stepSafari()
        {
            safari.PlayTurn();
        }

        ///<summary>
        /// Resets Safari by invoking Safari's Reset method.
        /// </summary>
        public void resetSafari()
        {
            safari.Reset();
        }
    }
}


