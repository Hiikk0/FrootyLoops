using FrootyLoops.Data.Entities;
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FrootyLoops.Services
{
    class InputChecker
    {
        /// <summary>
        /// Перевірка валідності даних, введених в логіні
        /// </summary>
        /// <param name="username">Введене ім'я користувача</param>
        /// <param name="password">Введений пароль</param>
        /// <returns>Список помилок з вказанням необхідних повідомлень</returns>
        public static List<string> InputCheck(string username, string password)
        {
            List<string> Errors = new List<string>();

            /// TODO: Clean up this code.
            if (username.IsNullOrEmpty())
            {
                Errors.Add("Username is empty.");
            }
            else if (!Directory.Exists(App.STDPATH + "/Users/" + username))
            {
                Errors.Add("Username is not exist.");
                return Errors;
            }
            if (password.Length <= 8)
            {
                Errors.Add("Your password is too short, must have at least 9 letters and numbers.");
            }
            else if (!password.Any(char.IsDigit))
            {
                Errors.Add("Your password must have digit.");
            }
            else if (!password.Any(char.IsLetter))
            {
                Errors.Add("Your password must have letters.");
            }
            if (Errors.Count == 0)
            {
                string path = App.STDPATH + "/Users/" + username + "/UserInfo.json";
                User user;
                try { user = JsonWorker.GetUser(path).GetValueOrDefault(); }
                catch
                {
                    Errors.Add("File \"UserInfo.json\" is corrupted. Please, recreate file or all profile.");
                    return Errors;
                }
                if (Encryptor.Сomparator(password, user.Password) == false)
                {
                    Errors.Add("Password is incorrect");
                    if (user.PasswordHint != null && !string.IsNullOrEmpty(user.PasswordHint.ToString()))
                    {
                        Errors.Add("Password Hint: " + user.PasswordHint.ToString());
                    }
                }
            }
            return Errors;
        }
        /// <summary>
        /// Перевірка валідності даних, введених при реєстрації
        /// </summary>
        /// <param name="username">Введене ім'я користувача</param>
        /// <param name="password">Введений пароль</param>
        /// <param name="mail">Введена ел. пошта</param>
        /// <returns>Список помилок з вказанням необхідних повідомлень</returns>
        public static List<string> InputRegCheck(string username, string password, string mail) 
        {
            List<string> Errors = new List<string>();
            /// TODO: Clean up this code.
            if (username.IsNullOrEmpty())
            {
                Errors.Add("Username is empty.");
            }
            else if (new string(Path.GetInvalidFileNameChars()).Any(username.Contains))
            {
                Errors.Add("Username contains invalid characters. Here are these /\\<>:*?|\0 .");
            }
            else if (Directory.Exists(App.STDPATH + "/Users/" + username))
            {
                Errors.Add("Username is exist.");
                return Errors;
            }
            if (password.Length <= 8)
            {
                Errors.Add("Your password is too short, must have at least 9 letters and numbers.");
            }
            else if (!password.Any(char.IsDigit))
            {
                Errors.Add("Your password must have digit.");
            }
            else if (!password.Any(char.IsLetter))
            {
                Errors.Add("Your password must have letters.");
            }
            if (mail.IsNullOrEmpty())
            {
                Errors.Add("Mail is Empty.");
            }
            else if (!mail.IsEmail()) 
            {
                Errors.Add("String is not valid mail.");
            }
            return Errors;
        }
    }
}
