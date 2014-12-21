namespace ControlT.Utils
{
    using System;

    public static class StringExtensionMethods
    {
        public static DateTime ToDate(this string texto)
        {
            var partes = texto.Split('-');
            return new DateTime(int.Parse(partes[2]), int.Parse(partes[1]), int.Parse(partes[0]));
        }
    }
}
