using System;
using System.Web;

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
        public OperatingSystem OperatingSystem { get; private set; }
        public SearchBot SearchBot { get; private set; }
        public bool IsSearchBot { get; private set; }

        public UserAgentInfo()
        {
            Load(HttpContext.Current.Request.UserAgent);
        }
        public UserAgentInfo(string userAgent)
        {
            Load(userAgent);
        }
        private void Load(string userAgent)
        {
            UserAgent = userAgent;
            Browser = Parser.GetBrowser(userAgent);
            Architecture = Parser.GetArchitecture(userAgent);
            OperatingSystem = Parser.GetOperatingSystem(userAgent);
            SearchBot = Parser.GetSearchBot(userAgent);
            IsSearchBot = SearchBot != SearchBot.NotSearchBot;
        }
    }

    public enum SearchBot
    {
        NotSearchBot = 0
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

    public enum OperatingSystem
    {
        Unknown = 0,
        Windows3_1 = 1,
        Windows95 = 2,
        Windows98 = 3,
        Windows2000 = 4,
        WindowsXP = 5,
        WindowsServer2003 = 6,
        WindowsVista = 7,
        Windows7 = 8,
        Windows8 = 9,
        WindowsNT4_0 = 10,
        WindowsME = 11,
        OpenBSD = 12,
        SunOS = 13,
        Linux = 14,
        MacOS = 15,
        QNX = 16,
        BeOS = 17,
        OS2 = 18
    }

    public class Parser
    {
        /// <summary>
        /// Get corresponding system architecture for given user agent
        /// http://stackoverflow.com/a/228267/356635
        /// </summary>
        public static OperatingSystem GetOperatingSystem(string userAgent)
        {
            if (userAgent.IndexOf("Windows 3.11", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.Windows3_1;
            if (userAgent.IndexOf("Windows 95", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.Windows95;
            if (userAgent.IndexOf("Windows 98", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.Windows98;
            if (userAgent.IndexOf("Windows 2000", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.Windows2000;
            if (userAgent.IndexOf("Windows XP", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.WindowsXP;
            if (userAgent.IndexOf("Windows Server 2003", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.WindowsServer2003;
            if (userAgent.IndexOf("Windows Vista", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.WindowsVista;
            if (userAgent.IndexOf("Windows 7", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.Windows7;
            if (userAgent.IndexOf("Windows 8", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.Windows8;
            if (userAgent.IndexOf("Windows NT 4.0", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.WindowsNT4_0;
            if (userAgent.IndexOf("Windows ME", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.WindowsME;
            if (userAgent.IndexOf("Open BSD", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.OpenBSD;
            if (userAgent.IndexOf("Sun OS", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.SunOS;
            if (userAgent.IndexOf("Linux", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.Linux;
            if (userAgent.IndexOf("Mac OS", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.MacOS;
            if (userAgent.IndexOf("QNX", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.QNX;
            if (userAgent.IndexOf("BeOS", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.BeOS;
            if (userAgent.IndexOf("OS/2", StringComparison.CurrentCultureIgnoreCase) != -1)
                return OperatingSystem.OS2;
            return OperatingSystem.Unknown;
        }

        /// <summary>
        /// Get the corresponding search bot for given user agent
        /// </summary>
        public static SearchBot GetSearchBot(string userAgent)
        {
            return SearchBot.NotSearchBot;
        }

        /// <summary>
        /// Get corresponding system architecture for given user agent
        /// http://stackoverflow.com/a/13709431/356635
        /// </summary>
        public static Architecture GetArchitecture(string userAgent)
        {
            if (userAgent.IndexOf("x86_64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("x86-64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("win64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("x64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("amd64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("wow64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("x64_64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("ia64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("sparc64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("ppc64", StringComparison.CurrentCultureIgnoreCase) != -1
                || userAgent.IndexOf("irix64", StringComparison.CurrentCultureIgnoreCase) != -1)
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
