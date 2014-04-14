using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

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
        //public Crawler Crawler { get; private set; }
        //public bool IsCrawler { get; private set; }
        public List<string> URLs { get; private set; }

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
            //Crawler = Parser.GetCrawler(userAgent);
            //IsCrawler = Crawler != Crawler.NotCrawler;
            URLs = Parser.GetUrls(userAgent);
        }
    }

    public enum Crawler
    {
        NotCrawler = 0,
        _008 = 1,
        ABACHOBot = 2,
        Accoona = 3,
        AddSugarSpiderBot = 4,
        AnyApexBot = 5,
        Arachmo = 6,
        BlitzBot = 7,
        BaiduSpider = 8,
        BecomeBot = 9,
        BeslistBot = 10,
        BillyBobBot = 11,
        Bimbot = 12,
        Bingbot = 13,
        Boitho = 14,
        BTBot = 15,
        CatchBot = 16,
        Cerberian = 17,
        Charlotte = 18,
        ConveraCrawler = 19,
        Cosmos = 20,
        Covario = 21,
        DataparkSearch = 22,
        DiamondBot = 23,
        Discobot = 24,
        Dotbot = 25,
        EmeraldShield = 26,
        Envolk = 27,
        EsperanzaBot = 28,
        Exabot = 29,
        FASTEnterpriseCrawler = 31,
        FASTWebCrawler = 32,
        FDSE = 33,
        FindLinks = 34,
        FurlBot = 35,
        FyberSpider = 36,
        G2Crawler = 37,
        Gaisbot = 38,
        GalaxyBot = 39,
        GenieBot = 40,
        Gigabot = 41,
        Girafabot = 42,
        Googlebot = 43,
        GooglebotImage = 44,
        GurujiBot = 45,
        HappyFunBot = 46,
        Hl_ftien_spider = 47,
        Holmes = 48,
        Htdig = 49,
        Iaskspider = 50,
        Ia_archiver = 51,
        ICCrawler = 52,
        Ichiro = 53,
        IgdeSpyder = 54,
        IRLbot = 55,
        IssueCrawler = 56,
        Jaxified = 57,
        Jyxobot = 58,
        KoepaBot = 59,
        Lwebis = 60,
        LapozzBot = 61,
        Larbin = 62,
        LDSpider = 63,
        LexxeBot = 64,
        LingueeBot = 65,
        LinkWalker = 66,
        Lmspider = 67,
        Lwptrivial = 68,
        Mabontland = 69,
        Magpie = 70,
        MediapartnersGoogle = 71,
        MJ12bot = 72,
        Mnogosearch = 73,
        Mogimogi = 74,
        MojeekBot = 75,
        Moreoverbot = 76,
        MorningPaper = 77,
        MSNBot = 78,
        MSRBot = 79,
        MVAClient = 80,
        MXBot = 81,
        NetResearchServer = 82,
        NetSeer = 83,
        NewsGator = 84,
        NGSearch = 85,
        NiceBot = 86,
        Noxtrumbot = 87,
        Nusearch = 88,
        NutchCVS = 89,
        Nymesis = 90,
        Obot = 91,
        Oegp = 92,
        Omgilibot = 93,
        OmniExplorer = 94,
        OozBot = 95,
        Orbiter = 96,
        PageBitesHyper = 97,
        Peew = 98,
        Polybot = 99,
        Pompos = 100,
        PostPost = 101,
        Psbot = 102,
        PycURL = 103,
        Qseero = 104,
        Radian6 = 105,
        RamPyBot = 106,
        RufusBot = 107,
        SandCrawler = 108,
        SBIder = 109,
        ScoutJet = 110,
        Scrubby = 111,
        SearchSight = 112,
        Seekbot = 113,
        SemanticDiscovery = 114,
        Sensis = 115,
        SEOChat = 116,
        SeznamBot = 117,
        ShimCrawler = 118,
        ShopWiki = 119,
        Shoula = 120,
        Silk = 121,
        Sitebot = 122,
        Snappy = 123,
        Sogou = 124,
        Sosospider = 125,
        SpeedySpider = 126,
        Sqworm = 127,
        StackRambler = 128,
        Suggybot = 129,
        SurveyBot = 130,
        SynooBot = 131,
        Teoma = 132,
        Terrawiz = 133,
        TheSuBot = 134,
        ThumbnailCZ = 135,
        TinEye = 136,
        TruwoGPS = 137,
        TurnitinBot = 138,
        TweetedTimes = 139,
        Twenga = 140,
        Updated = 141,
        URLfileBot = 142,
        VagaBondo = 143,
        Voila = 144,
        Vortex = 145,
        Voyager = 146,
        VYU2 = 147,
        WebCollage = 148,
        WebSquash = 149,
        WF84 = 150,
        WoFindeIch = 151,
        WompleFactory = 152,
        Xaldon = 153,
        Yacy = 154,
        YahooSlurp = 155,
        YahooSlurpChina = 156,
        YahooSeeker = 157,
        YahooSeekerTesting = 158,
        Yandex = 159,
        YandexImages = 160,
        Yasaklibot = 161,
        Yeti = 162,
        Yodao = 163,
        Yoogli = 164,
        Youdao = 165,
        Zao = 166,
        Zeal = 167,
        ZSpider = 168,
        ZyBorg = 169
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
        /// Return a list of URLS found in the user agent string
        /// http://stackoverflow.com/questions/10576686/c-sharp-regex-pattern-to-extract-urls-from-given-string-not-full-html-urls-but
        /// </summary>
        public static List<string> GetUrls(string userAgent)
        {
            var urls = new List<string>();

            var linkParser = new Regex(@"\b(?:http://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match m in linkParser.Matches(userAgent))
            {
                urls.Add(m.Value);
            }

            return urls;
        } 

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
        /// Get the corresponding crawler for given user agent
        /// http://www.useragentstring.com/pages/Crawlerlist/
        /// </summary>
        public static Crawler GetCrawler(string userAgent)
        {
            return Crawler.NotCrawler;
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
