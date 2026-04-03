using Newtonsoft.Json;
using System.IO;

namespace View.Model.Services;

/// <summary>
/// Класс отвечающий за сериализацию и десериализацию данных (контакты)
/// </summary>
public class ContactSerializer
{
    /// <summary>
    /// Имя файла куда сохраняются данные, не хранит путь 
    /// </summary>
    private const string FileName = "contacts.json";

    /// <summary>
    /// Хранит путь к папке "Мои документы".
    /// </summary>
    private static readonly string ContactsFolderPath =
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    /// <summary>
    /// Хранит полный путь к файлу (Папка + имя файла).
    /// </summary>
    private static readonly string ContactsDirectory =
        Path.Combine(ContactsFolderPath, "Contacts");

    /// <summary>
    /// Полный путь к файлу контакта
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Конструктор по умолчанию.
    /// Использует путь: Мои документы\Contacts\contacts.json
    /// </summary>
    public ContactSerializer() 
    {
        FilePath = Path.Combine(ContactsDirectory, FileName);
    }

    /// <summary>
    /// Метод сериализации данных коллекции контакта
    /// </summary>
    /// <param name="contact">Контакт для сохранения</param>
    /// <returns>true, при успешной записи и false, при исключении</returns>
    public bool SaveContact(IEnumerable<Contact> contacts)
    {
        try
        {
            string directory = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(FilePath, json);  
            return true;
        }
        catch(Exception ex) 
        {
            return false;

        }
    }

    /// <summary>
    /// Метод десериализации данных коллекции контактов
    /// </summary>
    /// <returns>Коллекцию контактов, при успешом превращении из JSON строки в объект С#, иначе пустой контакт</returns>
    public List<Contact> LoadContact()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
                if (contacts == null)
                {
                    return new List<Contact>();
                }
                else { return contacts; }
            }
            return new List<Contact>();

        }
        catch (Exception)
        {
            return new List<Contact>();
        }
    }
}