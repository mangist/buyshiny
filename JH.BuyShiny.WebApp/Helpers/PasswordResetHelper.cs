using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JH.BuyShiny.WebApp
{
    public static class PasswordResetHelper
    {
        /// <summary>
        /// Generates a random 6 character password
        /// </summary>
        /// <returns></returns>
        public static string Generate()
        {
            var dictionary = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var codeBuilder = new StringBuilder();
            var r = new Random();
            var dictLength = dictionary.Length;

            for (int i = 0; i < 6; i++)
            {
                codeBuilder.Append(dictionary[r.Next(0, dictLength)]);
            }

            return codeBuilder.ToString();
        }
    }
}