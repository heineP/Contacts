using System.Text.Json;

namespace Contacts.Lib;

public static class JsonUtil
{
    /// <summary>
    /// Loads the data from json file into a List with Contact objects
    /// </summary>
    public static List<Contact> GetJsonData(string jsonFileName)
    {
        string filepath = DirectoryUtil.GetDataFilepath(jsonFileName);
        string jsonData = File.ReadAllText(filepath);
        return JsonSerializer.Deserialize<List<Contact>>(jsonData)!;
    }
}