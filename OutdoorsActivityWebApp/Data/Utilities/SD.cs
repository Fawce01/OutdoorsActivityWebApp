using System.Text.RegularExpressions;

namespace OutdoorsActivityWebApp.Data.Utilities
{
    public static class SD
    {
        // Role strings
        public static string Role_Customer = "Customer";
        public static string Role_Instructor = "Instructor";
        public static string Role_Admin = "Admin";

        public enum ActivityType
        {
            OutdoorRockClimbing,
            IndoorRockClimbing,
            OutdoorBouldering,
            IndoorBouldering,
            Caving,
            Absailing,
            MountainBiking,
            Canoeing,
            Kayaking,
            Paddleboarding,
            Surfing,
            Sailing,
            Hiking,
            TrailRunning,
            Scrambling,
            Skiing,
            Snowboarding,
            Ziplining,
            Parkour, 
            Archery,
            Other,
        }

        public static string SplitUpperTextCase(string value)
        {
            return Regex.Replace(value,
        "(?<=[a-z])(?=[A-Z])|(?<=[A-Z])(?=[A-Z][a-z])",
        " ");
        }

    }
}
