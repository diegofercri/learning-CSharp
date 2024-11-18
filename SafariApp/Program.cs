using SafariApp.controller;
using SafariApp.model;
using SafariApp.view;

namespace SafariApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Safari mySafari = new Safari (10, 10);
            Controller controller = new Controller (mySafari);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault (false);

            Window window = new window(controller); 

            Application.Run(window);
        }
    }
}