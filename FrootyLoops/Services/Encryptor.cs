using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FrootyLoops.Services
{
    public class Encryptor
    {
        /// <summary>
        /// Хешує отримані дані
        /// </summary>
        /// <param name="password">Дані для хешування (пароль)</param>
        /// <returns>Дані у хешованому вигляді</returns>
        public static string Encrypt(string password)
        {
            byte[] salt = SHA512.HashData(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();

            // Преобразование байтового массива в строку
            for (int i = 0; i < salt.Length; i++)
            {
                sb.Append(salt[i].ToString("x2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// Перевірка на відповідність
        /// </summary>
        /// <param name="password">Нехешовані дані</param>
        /// <param name="hash">Хешовані дані</param>
        /// <returns>Збіглися дані чи ні</returns>
        public static bool Сomparator(string password, string hash)
        {
            if (Encryptor.Encrypt(password) == hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
