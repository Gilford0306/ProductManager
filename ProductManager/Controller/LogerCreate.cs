namespace ProductManager.Controller
{
    public enum LogLevel
    {
        Information,
        Warning,
        Error

    }
    public static class LogerCreate
    {
        private static string path { get; set; }
        static LogerCreate() => path = "database.log";

        public static void SetPath(string pathToLogFile) => path = pathToLogFile;
        public static void Log(string? msg, LogLevel logLevel = LogLevel.Error) =>
            File.AppendAllText(path,
                $"{DateTime.Now.ToString()}:{DateTime.Now.Millisecond}|" +
                $" {logLevel} |" +
                $" {msg}\n");
    }
}
