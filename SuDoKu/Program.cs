using System;

namespace SuDoKu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* Remember to change teh app settings to target teh correct output type */
            /* Code for form app */
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */

            /* Code for console app */
            new SudokuGameController(new ConsoleView(), new SudokuGame()).Go();
        }
    }
}

