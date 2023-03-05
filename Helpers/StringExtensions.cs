using System;
using System.Text;

namespace ComputerConfigurator.Helpers
{
    public static class StringExtensions
    {
        public static string GetFirstInt(this string Source)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool stop = false;
            foreach (var c in Source)
            {
                if (char.IsDigit(c))
                {
                    stringBuilder.Append(c);
                    stop = true;
                    continue;
                }
                if (stop)
                    break;
            }
            return stringBuilder.ToString();
        }

        public static string GetFirstDouble(this string Source)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool stop = false;
            foreach (var c in Source)
            {
                if (char.IsDigit(c) || (c == '.' && stop))
                {
                    stringBuilder.Append(c);
                    stop = true;
                    continue;
                }
                if (stop)
                    break;
            }
            return stringBuilder.ToString().Replace('.', ','); ;
        }

        public static string GetLastInt(this string Url)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool stop = false;
            for (int i = Url.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(Url[i]))
                {
                    stringBuilder.Append(Url[i]);
                    stop = true;
                    continue;
                }
                if (stop)
                    break;
            }
            return Reverse(stringBuilder.ToString());
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
