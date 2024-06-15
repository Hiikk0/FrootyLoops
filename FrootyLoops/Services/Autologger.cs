using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FrootyLoops.Data.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FrootyLoops.Services
{
    public class Autologger
    {
        /// <summary>
        /// Ім'я поточного користувача
        /// </summary>
        public static string NAME = "";
        /// <summary>
        /// Створення файлу для зберігання поточного користувача
        /// </summary>
        /// <param name="path"></param>
        public static void Create(string path)
        {
            File.WriteAllText(Path.GetFullPath(Path.Combine(path, "..", "..") + "/user.json"), Encryptor.Encrypt(CurrentUser.user.Name + CurrentUser.user.Password));
        }
        /// <summary>
        /// Рекурсійна перевірка користувачів
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Compare(string path)
        {
            List<string> listPath = Directory.EnumerateDirectories(path).ToList();
            foreach (string pathToUser in listPath)
            {
                CurrentUser.LoadUser(pathToUser + "/UserInfo.json");
                if (Encryptor.Encrypt(Path.GetFileName(pathToUser) + CurrentUser.user.Password) == File.ReadAllText(path + "/user.json"))
                {
                    NAME = Path.GetFileName(pathToUser);
                    return true;
                }
            }
            return false;
        }
    }
}
