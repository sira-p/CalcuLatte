/*
 * File: CalcuLatte\Program.cs
 * CalcuLatte Version 1.1
 * Author: Sira Pornsiriprasert
 * MIT License https://psira.mit-license.org/
 */

namespace CalcuLatte
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }
    }
}