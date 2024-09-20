using Contacts.Lib;
namespace Contacts;

public class PhoneBook
{
    public Contact[] Contacts; // left it public just to show if sort works or not, because i didn't make a DisplayAll.
    private string? SortBy { get; set; }
    private string? Order { get; set; }
    
    
    // Consctructor
    public PhoneBook(string jsonfilename)
    {
        Contacts = JsonUtil.GetJsonData(jsonfilename).ToArray();
    }
    
    
    public void Display(Contact contact)
    {
        // box width: 40
        Console.WriteLine("________________________________________");
        Console.WriteLine($"| Name: {contact.FirstName}{Tools.WhiteSpaces(7, contact.FirstName)}|");
        Console.WriteLine($"| Surname: {contact.LastName}{Tools.WhiteSpaces(10, contact.LastName)}|");
        Console.WriteLine($"| Phone: {contact.MobileNumber}{Tools.WhiteSpaces(8, contact.MobileNumber)}|");
        Console.WriteLine($"| Date Of Birth: {contact.DateOfBirth}{Tools.WhiteSpaces(16, contact.DateOfBirth.ToString())}|");
        Console.WriteLine($"| Address: {contact.Address?[0]},{Tools.WhiteSpaces(11, contact.Address?[0])}|");
        Console.WriteLine($"|          {contact.Address?[1]}{Tools.WhiteSpaces(10, contact.Address?[1])}|");
        Console.WriteLine("|______________________________________|");
    }

    
    /// <summary>
    /// Search PhoneBook for Contacts with properties matching the search string.
    /// Uses Linear search.
    /// </summary>
    /// <param name="searchString">Search with case insensitive string.</param>
    /// <param name="display">Optional: Set to False to opt out of displaying results.</param>
    /// <returns>The objects that contains properties matching the search.</returns>
    public Contact[]? Search(string searchString, bool display = true)
    {
        Console.WriteLine($"Searching for: {searchString}...");
        
        string s = searchString.ToLower();
        
        List<Contact> results = new List<Contact>();

        for (int i = 0; i < Contacts.Length; i++)
        {
            if (Contacts[i].FirstName?.ToLower() == s ||
                Contacts[i].LastName?.ToLower() == s ||
                Contacts[i].MobileNumber == s ||
                Contacts[i].DateOfBirth.ToString() == s ||
                Contacts[i].Address?[0].ToLower() == s ||
                Contacts[i].Address?[1].ToLower() == s)
            {
                results.Add(Contacts[i]);
                
                // prints results if display is true
                if (display)
                {
                    Display(Contacts[i]);
                    
                }
            }
        }
        
        if (results.Count == 0)
        {
            Console.WriteLine("No results");
            return null;
        }
        else
        {   
            Console.WriteLine($"Found {results.Count} results");
            return results.ToArray();
        }
    }

    /// <summary>
    /// Sorting Contacts based on sort options.
    /// </summary>
    /// <param name="sortBy">Optional: Default = name. Valid parameters: name, lastname, mobilenumber, dateofbirth, address</param>
    /// <param name="order">Optional: Sort by ascending or descending order, default = asc. Valid values: ascending, descending</param>
    public void Sort(string sortBy = "name", string order = "ascending")
    {
        // stores sortBy choice in class so that it can be used in helper methods
        if (sortBy.ToLower() == "name" ||
            sortBy.ToLower() == "lastname" ||
            sortBy.ToLower() == "mobilenumber" ||
            sortBy.ToLower() == "dateofbirth" ||
            sortBy.ToLower() == "address")
        {
            string sb = sortBy.ToLower();
            SortBy = sb;
        }
        else
        {
            Console.WriteLine("Sorting by name is not supported, defaulting to first name");
            SortBy = "name";
        }

        // stores ascending/descending order in class
        if (order.ToLower() == "ascending" || 
            order.ToLower() == "descending")
        {
            Order = order.ToLower();

        }
        else
        {
            Console.WriteLine("Ordering by name is not supported. defaulting to sorting by: Ascending order");
            Order = "ascending";
        }
        
        Console.WriteLine($"Sorting PhoneBook by: {SortBy} in {Order} order...");
        QuickSort(Contacts, 0, Contacts.Length - 1);
        Console.WriteLine($"Sort finished.");
    }
    
    
    private void QuickSort(Contact[] array, int left, int right)
    {
        if (left < right) // if left index is less than right index, there is nothing more in this part to sort
        {
            int pivotIndex = Partition(array, left, right);
        
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
    }
    
    
/// <summary>
/// Help method for QuickSort, does the partitioning part of the quick sort algorithm
/// </summary>
/// <param name="array">The array that is being sorted</param>
/// <param name="left">Start index of next part of array to be sorted</param>
/// <param name="right">End index of nest part of array to be sorted</param>
/// <returns>index of next pivot</returns>
    private int Partition(Contact[] array, int left, int right)
    {
        // need to set pivot based on sort setting
        // pivot is the last element of the part of the array we're splitting next
        string? pivot;
        switch (SortBy)
        {
            case "surname":
                pivot = array[right].LastName;
                break;
            case "phone":
                pivot = array[right].MobileNumber;
                break;
            case "dateofbirth":
                pivot = array[right].DateOfBirth.ToString();
                break;
            case "address":
                pivot = array[right].Address?[0] + array[right].Address?[1];
                break;
            default:
                pivot = array[right].FirstName;
                break;
        }
        
        int j = left - 1;  // help index. put all elements less than pivot on j, and then do i++;

        for (int i = left; i < right; i++)
        {

            // place all elements less than pivot to the left of pivot based on sorting choice
            switch (SortBy)
            {
                case "surname":
                    if (Order == "ascending" ? String.Compare(array[i].LastName, pivot) <= 0 : String.Compare(array[i].LastName, pivot) > 0)
                    {
                        j++;
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                    break;
                case "phone":
                    if (Order == "ascending" ? String.Compare(array[i].MobileNumber, pivot) <= 0 : String.Compare(array[i].MobileNumber, pivot) > 0)
                    {
                        j++;
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                    break;
                case "dateofbirth":
                    if (Order == "ascending" ? string.Compare(array[i].DateOfBirth.ToString(), pivot) <= 0 : string.Compare(array[i].DateOfBirth.ToString(), pivot) > 0)
                    {
                        j++;
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                    break;
                case "address":
                    if (Order == "ascending" ? string.Compare(array[i].Address?[0] + array[i].Address?[1], pivot) <= 0 : string.Compare(array[i].Address?[0] + array[i].Address?[1], pivot) > 0)
                    {
                        j++;
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                    break;
                default:
                    if (Order == "ascending" ? String.Compare(array[i].FirstName, pivot) <= 0 : String.Compare(array[i].FirstName, pivot) > 0)
                    {
                        j++;
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                    break;
            }
            
        }
        // changing pivot position
        (array[j + 1], array[right]) = (array[right], array[j + 1]);

        return j + 1;
    }
}