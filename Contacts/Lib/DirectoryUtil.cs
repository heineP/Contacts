namespace Contacts.Lib;

public static class DirectoryUtil
{
    /// <param name="levelsBack">The number of levels to move up towards the root directory.</param>
    /// <returns>The full file path after traversing the specified number of levels.</returns>
    public static string GetParentDirectory(int levelsBack)
    {
        string filepath = Directory.GetCurrentDirectory();

        for (int i = 0; i < levelsBack; i++)
        {
            filepath = Directory.GetParent(filepath)!.FullName;
        }
        
        return filepath;
    }
    
    /// <param name="jsonFileName">Name of the json file</param>
    /// <returns>The full file path to json file after combining with exe-filepath and Data folder</returns>
    public static string GetDataFilepath(string jsonFileName)
    {
        if (string.IsNullOrEmpty(jsonFileName))
        {
            throw new ArgumentNullException(nameof(jsonFileName), "Filename cannot be null or empty.");
        }
        
        string filepath = GetParentDirectory(3);
        
        if (!Directory.Exists(Path.Combine(filepath, "Data")))
        {
            throw new DirectoryNotFoundException($"Cannot find Data directory in: {filepath}");
        }
        if (!File.Exists(Path.Combine(filepath, "Data", jsonFileName)))
        {
            throw new DirectoryNotFoundException($"Cannot find Json file in: {Path.Combine(filepath, "Data")}");
        }

        return Path.Combine(filepath, "Data", jsonFileName);
    }
}