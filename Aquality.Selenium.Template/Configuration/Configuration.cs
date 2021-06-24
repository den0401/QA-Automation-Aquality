namespace Aquality.Selenium.Template.Configuration
{
    public static class Configuration
    {
        public static string StartUrl => Environment.CurrentEnvironment.GetValue<string>("startUrl");

        public static string WaitingTime => Environment.CurrentEnvironment.GetValue<string>("waitingTime");

        public static string WindowsWindowName => Environment.CurrentEnvironment.GetValue<string>("windowsWindowName");

        public static string PathToImage => Environment.CurrentEnvironment.GetValue<string>("pathToImage");

        public static string TimerValue => Environment.CurrentEnvironment.GetValue<string>("timerValue");
    }
}
