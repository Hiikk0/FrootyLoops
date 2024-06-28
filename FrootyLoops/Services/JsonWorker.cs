using FrootyLoops.Data.Entities;
using FrootyLoops.UserControls.WorkplaceContent;
using HandyControl.Controls;
using HandyControl.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace FrootyLoops.Services
{
    public class JsonWorker
    {
        /// <summary>
        /// Ініціалізація налаштувань.
        /// </summary>
        public static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true,
            //ReferenceHandler = ReferenceHandler.Preserve,
        };
        /// <summary>
        /// Створення Json файлу
        /// </summary>
        /// <param name="strings"> Об'єкт (зазвичай структура), яку треба перетворити на файл</param>
        /// <param name="path"> Шлях, де створюється файл</param>
        public static void CreateJson(object strings, string path)
        {

            string json = JsonSerializer.Serialize(strings, JsonWorker.options);
            File.WriteAllText(path, json);
        }
        /// <summary>
        /// Оновлює вже існуючий файл Json.
        /// </summary>
        /// <param name="key">Ключ, по якому треба змінити дані</param>
        /// <param name="Value">Дані, на які треба замінити</param>
        /// <param name="path">Шлях до файлу</param>
        public static void UpdateJson(string key, object Value, string path)
        {
            Dictionary<string,object> dict = LoadFromJson(path);
            if (dict.ContainsKey(key) )
            {
                dict[key] = Value; 
            }
            string json = JsonSerializer.Serialize(dict, JsonWorker.options);
            File.WriteAllText(path, json);
        }
        /// <summary>
        /// Завантажує файл json з носія
        /// </summary>
        /// <param name="path">Шлях, де знаходиться файл</param>
        /// <returns>Словник (ключ-значення), отриманий з файлу</returns>
        public static Dictionary<string,object> LoadFromJson(string path)
        {
            string json = "";
            Dictionary<string, object> returnJson = new();
            try
            {
                json = File.ReadAllText(path);

            }
            catch(System.UnauthorizedAccessException ex)
            {
                Growl.ErrorGlobal(new GrowlInfo
                {
                    Message = ex.Message +
                " Please check the permissions for the app.",
                    Type = InfoType.Error,
                    WaitTime = 10,
                });
            }
            catch (IOException ex){
                Growl.ErrorGlobal(new GrowlInfo
                {
                    Message = ex.Message +
                " Please check the availability of this file.",
                    Type = InfoType.Error,
                    WaitTime = 10,
                });
            }
            catch(Exception ex)
            {
                Growl.ErrorGlobal(new GrowlInfo
                {
                    Message = "Critical errors occurred when creating the profile: "
                    + ex.Message + " Please report this bug to the developer.",
                    Type = InfoType.Error,
                    WaitTime = 10,
                });
            }
            try
            {
                returnJson = !string.IsNullOrWhiteSpace(json)
                   ? JsonSerializer.Deserialize<Dictionary<string, object>>(json)
                   : new Dictionary<string, object>();
            }
            catch (Exception)
            {
                Growl.ErrorGlobal(new GrowlInfo
                {
                    Message = "File \"UserInfo.json\" is corrupted. " +
                    "Please, recreate file or all profile.",
                    Type = InfoType.Error,
                    WaitTime = 10,
                });
            }
            return returnJson;
        }
        /// <summary>
        /// Отримання поточного користувача
        /// </summary>
        /// <param name="path">Шлях до користувача</param>
        /// <returns>Сутність поточного користувача</returns>
        public static User? GetUser(string path)
        {
           
            try { User user = JsonSerializer.Deserialize<User>(File.ReadAllText(path)); return user; }
            catch (JsonException err) {
                Growl.ErrorGlobal(new GrowlInfo
                {
                    Message = err.Message + " Recreate or restore file.",
                    Type = InfoType.Error,
                    WaitTime = 10,
                });
                return null;
            }
            catch (IOException err)
            {
                Growl.ErrorGlobal(new GrowlInfo
                {
                    Message = err.Message + " Close all apps, which use this file. If doesn't help, recreate or restore file.",
                    Type = InfoType.Error,
                    WaitTime = 10,
                });
                return null;
            }
            catch (Exception err)
            {
                Growl.ErrorGlobal(new GrowlInfo
                {
                    Message = err.Message + " Please report this bug to the developer.",
                    Type = InfoType.Error,
                    WaitTime = 10,
                });
                return null;
            }
        }
        /// <summary>
        /// Отримання поточного користувача
        /// </summary>
        /// <param name="path">Шлях до користувача</param>
        /// <returns>Сутність поточного користувача</returns>
        public static List<MusicBlockData>? GetMusicBlock(string path)
        {
            //RootObjectForList list;
            //try 
            //{
            //    var jsonString = File.ReadAllText(path);
            //    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            //    list = JsonSerializer.Deserialize<RootObjectForList>(jsonString, options);
            //}
            //catch (JsonException err)
            //{
            //    Growl.ErrorGlobal(new GrowlInfo
            //    {
            //        Message = err.Message + " Recreate or restore file.",
            //        Type = InfoType.Error,
            //        WaitTime = 10,
            //    });
            //    return null;
            //}
            //catch (IOException err)
            //{
            //    Growl.ErrorGlobal(new GrowlInfo
            //    {
            //        Message = err.Message + " Close all apps, which use this file. If doesn't help, recreate or restore file.",
            //        Type = InfoType.Error,
            //        WaitTime = 10,
            //    });
            //    return null;
            //}
            //catch (Exception err)
            //{
            //    Growl.ErrorGlobal(new GrowlInfo
            //    {
            //        Message = err.Message + " Please report this bug to the developer.",
            //        Type = InfoType.Error,
            //        WaitTime = 10,
            //    });
            //    return null;
            //}
            List<MusicBlockData> blockData = null;
            try
            {
                blockData = JsonSerializer.Deserialize<List<MusicBlockData>>(File.ReadAllText(path));
            }
            catch (JsonException err)
            {
                Growl.ErrorGlobal(new GrowlInfo
                {
                    Message = err.Message + " Recreate or restore file.",
                    Type = InfoType.Error,
                    WaitTime = 10,
                });
                return null;
            }
            return blockData;
        }
    }
}
