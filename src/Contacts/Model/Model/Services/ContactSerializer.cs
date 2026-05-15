using Newtonsoft.Json;
using System.IO;

namespace Model.Model.Services;

/// <summary>
/// Класс, отвечающий за сериализацию и десериализацию данных (контактов).
/// </summary>
/// <remarks>
/// Данные сохраняются в JSON-файл по пути: Мои документы\Contacts\contacts.json
/// При ошибках чтения/записи метод LoadContact возвращает пустой список,
/// метод SaveContact возвращает false (без проброса исключений).
/// </remarks>
public class ContactSerializer
{
    /// <summary>
    /// Имя файла для сохранения контактов (без пути).
    /// </summary>
    private const string FileName = "contacts.json";

    /// <summary>
    /// Путь к папке "Мои документы" текущего пользователя.
    /// </summary>
    private static readonly string MyDocumentsPath =
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    /// <summary>
    /// Путь к папке Contacts внутри "Моих документов".
    /// </summary>
    private static readonly string ContactsFolderPath =
        Path.Combine(MyDocumentsPath, "Contacts");

    /// <summary>
    /// Полный путь к файлу контактов (включая имя файла).
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Инициализирует новый экземпляр сериализатора.
    /// Использует путь: Мои документы\Contacts\contacts.json
    /// </summary>
    public ContactSerializer()
    {
        FilePath = Path.Combine(ContactsFolderPath, FileName);
    }

    /// <summary>
    /// Сохраняет коллекцию контактов в JSON-файл.
    /// </summary>
    /// <param name="contacts">Коллекция контактов для сохранения.</param>
    /// <returns>
    /// true — при успешной записи;
    /// false — при возникновении ошибки (например, нет прав на запись, диск заполнен).
    /// </returns>
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
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Загружает коллекцию контактов из JSON-файла.
    /// </summary>
    /// <returns>
    /// Список контактов из файла. Если файл не существует, повреждён или содержит некорректный JSON,
    /// возвращается пустой список (не null).
    /// </returns>
    public List<Contact> LoadContact()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                return new List<Contact>();
            }

            string json = File.ReadAllText(FilePath);
            List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(json);

            return contacts ?? new List<Contact>();
        }
        catch
        {
            return new List<Contact>();
        }
    }
}