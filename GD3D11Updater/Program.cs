using System;
using System.IO;
using System.Windows.Forms;

namespace GD3D11Updater
{
    /// <summary>
    /// Static class to hold the log-function
    /// </summary>
    static class LogClass
    {
        /// <summary>
        /// Outputs a string into the log-file.
        /// </summary>
        /// <param name="line">Text to be written out.</param>
        public static void LogLine(string line)
        {
            using (StreamWriter log = new StreamWriter(Properties.Settings.Default.logfile, true))
            {
                log.WriteLine("-- > G2D3D11Updater " + line);
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            LogClass.LogLine("Program: Starting updater");
            LogClass.LogLine("Program: Args: " + string.Join(", ", args));

            LogClass.LogLine("Program: EnableVisualStyles");
            Application.EnableVisualStyles();

            LogClass.LogLine("Program: SetCompatibleTextRenderingDefault(false)");
            Application.SetCompatibleTextRenderingDefault(false);

            // args = <version>, gothic's process id
            if (args.Length != 2)
            {
                LogClass.LogLine("Program: Wrong args: " + string.Join(", ", args));
                MessageBox.Show("Wrong updater parameters.", "Error", MessageBoxButtons.OK);
                return;
            }

            LogClass.LogLine("Program: Run CheckWin");
            Application.Run(new CheckWin(args[0], int.Parse(args[1])));
            LogClass.LogLine("Program: Closing");
        }
    }
}
