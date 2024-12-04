using SafariApp_v2.Model;

namespace SafariApp_v2.Controller
{
    internal class Controller
    {
        private Safari safari;

        public Controller(Safari safari)
        {
            this.safari = safari;
        }

        public Being[,] getBeings()
        {
            return safari.GetBeings();
        }

        public void playSafari()
        {

        }
        public void pauseSafari()
        {

        }
        public void stopSafari()
        {

        }
        public void resetSafari()
        {
            safari.Reset();
        }
        public void stepSafari()
        {
            safari.PlayTurn();

        }
    }
}


