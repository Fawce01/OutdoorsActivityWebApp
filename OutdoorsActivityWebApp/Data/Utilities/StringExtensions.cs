
namespace OutdoorsActivityWebApp.Data.Utilities
{
    public static class StringExtensions
    {
        public static string ToReadableString(this string value)
        {
            return SD.SplitUpperTextCase(value.ToString());
        }
    }
}
