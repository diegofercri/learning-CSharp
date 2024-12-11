﻿using SafariApp_v2.Controller;
using SafariApp_v2.Model;
using SafariApp_v2.View;
using System;
using System.Windows.Forms;

namespace SafariApp_v2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Safari safari = new Safari(10, 10, 20, 10, 0);
            SafariController controller = new SafariController(safari);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm window = new MainForm(controller);

            Application.Run(window);
        }
    }
}
