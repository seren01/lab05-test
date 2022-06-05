using System.Text.RegularExpressions;

namespace Packt.Shared
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            // используйте простое регулярное выражение
            // для проверки того, что входная строка — реальный
            // адрес электронной почты
            return Regex.IsMatch(input,
            @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}