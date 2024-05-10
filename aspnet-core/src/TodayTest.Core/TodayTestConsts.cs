using TodayTest.Debugging;

namespace TodayTest
{
    public class TodayTestConsts
    {
        public const string LocalizationSourceName = "TodayTest";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "7525ba8f5ff74d5bb82ea8b8590315f9";
    }
}
