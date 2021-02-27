using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lib.Common.Helpers
{
    public static class AppHelpers
    {
        #region string does not contains special characters
        public static bool HasSpecialChar(string input)
        {
            const string SPECIAL_CHAR = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            return SPECIAL_CHAR.Any(input.Contains);
        }
        #endregion
        
        #region check email is valid
        public static bool IsValidEmail(this string email)
        {
            const string PATTERN = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(PATTERN, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        #endregion
        
        #region remove diacritics
        public static string RemoveDiacritics(string text)
        {
            var formD = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char ch in formD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        #endregion

        #region password checking
        public static bool PasswordValid(string input)
        {
            const string SPECIAL_CHAR = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            const string UPPERCASE = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string LOWERCASE = @"abcdefghijklmnopqrstuvwxyz";
            const string NUMBER = @"1234567890";
            return SPECIAL_CHAR.Any(input.Contains) &&
                   (UPPERCASE.Any(input.Contains) && (LOWERCASE.Any(input.Contains) && NUMBER.Any(input.Contains)));
        }
        #endregion

        #region caculate duration time to now
        public static string GetDurationToNow(DateTime startDate)
        {
            string timeChat;
            var subSecond = DateTime.Now.Ticks / TimeSpan.TicksPerSecond - startDate.Ticks / TimeSpan.TicksPerSecond; // second
            if (subSecond > 0 && subSecond < 60)
            {
                timeChat = subSecond + " giây trước";
            }
            else if (subSecond >= 60 && subSecond < 3600)
            {
                timeChat = subSecond / 60 + " phút trước";
            }
            else if (subSecond >= 3600 && subSecond < 86400)
            {
                timeChat = subSecond / 3600 + " giờ trước";
            }
            else if (subSecond >= 86400)
            {
                timeChat = subSecond / 86400 + " ngày trước";
            }
            else
            {
                timeChat = "0 giây trước";
            }
            return timeChat;
        }
        #endregion
    }
}
