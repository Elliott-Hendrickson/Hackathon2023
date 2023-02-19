using DuckAPP.Properties.InternetChecker;
using System.Diagnostics;
using static DuckAPP.Properties.InternetChecker.BrowserSearcherClass;

namespace DuckAPP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}