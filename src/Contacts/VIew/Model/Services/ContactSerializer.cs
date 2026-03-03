using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Model;

namespace View.Model.Services
{
    /// <summary>
    /// Класс отвечающий за сериализацию и десериализацию данных (контакты)
    /// </summary>
    class ContactSerializer
    {
        /// <summary>
        /// Имя файла куда сохраняются данные, не хранит путь 
        /// </summary>
        private const string FileName = "contacts.json";

        /// <summary>
        /// Хранит путь к папке "Мои документы".
        /// </summary>
        private static readonly string DocumentsPath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Хранит полный путь к файлу (Папка + имя файла).
        /// </summary>
        private static readonly string ContactsDirectory =
            Path.Combine(DocumentsPath, "Contacts");
        /// <summary>
        /// Полный путь к файлу контакта
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// Использует путь: Мои документы\Contacts\contacts.json
        /// </summary>
        public ContactSerializer()
        {
            FilePath = Path.Combine(ContactsDirectory, FileName);
        }
        /// <summary>
        /// Метод сериализации данных контакта
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>true, при успешной записи и false, при исключении</returns>
        public bool SaveContact(Contact contact)
        {
            try
            {
                string directory = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string json = JsonConvert.SerializeObject(contact, Formatting.Indented);

                // Записываем в файл
                File.WriteAllText(FilePath, json);

                return true;
            }
            catch(Exception ex) 
            {
                return false;

            }
        }
        /// <summary>
        /// Метод десериализации данных контакта
        /// </summary>
        /// <returns>Контакт, при успеном превращении из JSON строки в объект С#, иначе пустой контакт</returns>
        public Contact LoadContact()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    Contact contact = JsonConvert.DeserializeObject<Contact>(json);
                    if (contact == null)
                    {
                        return new Contact();
                    }
                    else { return contact; }
                }
                return new Contact();

            }
            catch (Exception ex)
            {
                return new Contact();
            }
        }
    }
}