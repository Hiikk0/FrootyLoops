using FrootyLoops.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FrootyLoops.Data.Entities
{
    /// <summary>
    /// Структура сутності
    /// </summary>
    public struct User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PasswordHint { get; set; }
        public string RegDateString { get; set; }
        public string LastLogDataTimeString { get; set; }

        [JsonIgnore]
        public DateTime RegDate
        {
            get
            {
                DateTime.TryParse(RegDateString, out DateTime regDate);
                return regDate;
            }
            set
            {
                RegDateString = value.ToString("o"); // Convert to round-trip format
            }
        }

        [JsonIgnore]
        public DateTime LastLogDataTime
        {
            get
            {
                DateTime.TryParse(LastLogDataTimeString, out DateTime lastLogDateTime);
                return lastLogDateTime;
            }
            set
            {
                LastLogDataTimeString = value.ToString("o"); // Convert to round-trip format
            }
        }
        public void Clear()
        {
            CurrentUser.user.Name = "";
            CurrentUser.user.Email = "";
            CurrentUser.user.Password = "";
            CurrentUser.user.PasswordHint = "";
            CurrentUser.user.RegDateString = "";
            CurrentUser.user.LastLogDataTimeString = "";
        }
    }
    public class CurrentUser()
    {
        public static User user;
        public static void LoadUser(string path)
        {
            user = JsonWorker.GetUser(path).GetValueOrDefault();
        }
        public static void Clear() { user.Clear(); }
    }
}
