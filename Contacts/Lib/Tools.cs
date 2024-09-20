namespace Contacts.Lib;

public static class Tools
{
    public static string WhiteSpaces(int alreadyFilled, string? variable)
    {
        int sNeeded = 38 - alreadyFilled;
        if (variable != null)
        {
            sNeeded -= variable.Length;
        }
        
        string spaces = "";
        for (int i = 0; i < sNeeded; i++)
        {
            spaces += " ";
        }

        return spaces;
    }
}