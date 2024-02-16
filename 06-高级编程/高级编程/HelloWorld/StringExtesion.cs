namespace HelloWorld
{
    internal static class StringExtesion
    {
        // 扩展方法 Extesion
        public static string ShortTerm(this string text, int number)
        {
            // 范围运算符
            return text[0..number];
        }
    }
}
