namespace SprdCore
{
    public static class StringExtensions
    {
        public static string AddTokenParameter(this string relativeUrl, string code)
        {
            return relativeUrl + "?code=" + code;
        }
    }
}