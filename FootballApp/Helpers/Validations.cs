using System.Text.RegularExpressions;

namespace FootballApp.Helpers
{
    public static class Validations
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success;
        }
    }
}