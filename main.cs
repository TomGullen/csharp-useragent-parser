using System;

namespace v2.Tracker
{
    /// <summary>
    /// A user agent
    /// </summary>
    public class UserAgentInfo
    {
        public string UserAgent { get; private set; }
        public Browser Browser { get; private set; }
        public Architecture Architecture { get; private set; }

        public UserAgentInfo(string userAgent)
        {
            UserAgent = userAgent;
            Browser = Parser.GetBrowser(userAgent);
            Architecture = Parser.GetArchitecture(userAgent);
        }
    }

    public enum Browser
    {
        Unknown = 0,
        FireFox = 1,
        InternetExplorer = 2,
        Chrome = 3,
        Safari = 4,
        Opera = 5,
        Android = 6,
    }

    public enum Architecture
    {
        x64 = 1,
        x32 = 2
    }

    public class Parser
    {
        /// <summary>
        /// Get corresponding system architecture for given user agent
        /// </summary>
        public static Architecture GetArchitecture(string userAgent)
        {
            if (userAgent.IndexOf("wow64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("win64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("i686", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("x64", StringComparison.CurrentCultureIgnoreCase) != -1)
                return Architecture.x64;
            return Architecture.x32;
        }

        /// <summary>
        /// Get corresponding browser for given user agent
        /// </summary>
        public static Browser GetBrowser(string userAgent)
        {
            if(userAgent.IndexOf("firefox", StringComparison.CurrentCultureIgnoreCase) != -1)
                return Browser.FireFox;
            if (userAgent.IndexOf("ie", StringComparison.CurrentCultureIgnoreCase) != -1)
                return Browser.InternetExplorer;
            if (userAgent.IndexOf("chrome", StringComparison.CurrentCultureIgnoreCase) != -1)
                return Browser.Chrome;
            if (userAgent.IndexOf("android", StringComparison.CurrentCultureIgnoreCase) != -1)
                return Browser.Android;
            if (userAgent.IndexOf("safari", StringComparison.CurrentCultureIgnoreCase) != -1)
                return Browser.Safari;
            if (userAgent.IndexOf("opera", StringComparison.CurrentCultureIgnoreCase) != -1)
                return Browser.Opera;

            return Browser.Unknown;
        }
    }
}
