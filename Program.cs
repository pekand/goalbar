namespace GoalBar
{
    internal static class Program
    {
        public static Log log = null;
        public static Config config = null;
        public static ConfigFile configFile = null;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Program.config = new Config();
            Program.log = new Log(config);
            Program.configFile = new ConfigFile(config, Program.log);
            Program.configFile.Load();
            FielChangeDetector.changed(Program.config.configPath);
            Program.log.write("Program start");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormGoalBar());
            Program.log.write("Program end");
        }
    }
}