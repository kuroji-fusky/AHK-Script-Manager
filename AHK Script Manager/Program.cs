using System.Runtime.InteropServices;

namespace AHK_Script_Manager
{
    internal static class Program
    {
        /// <summary>
        ///  entry point lmao
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}