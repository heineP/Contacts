# Contacts

A console app used for storing, sorting and searching through contacts.


### How to use
1. Open solution or project with a software editing tool.
2. Make sure JSON files containing the data you want to use is in the Contacts/Data folder.
3. If you want to use another JSON file than the one provided, use its name as a parameter when instantiating PhoneBook on line 5 in program.cs.
4. Use phoneBook.Search or Sort as you like - with required and optional parameters.


### Requirements
An IDE of your choice.


### Search
Uses a Linear search algorithm and allows you to search through the phonebook for properties containing the search input.
Properties you can search for: Name, Surname, Phone, Date of Birth, City, Street.
You can set the optional second parameter to false if you don't want to Display the search results.


### Sort
Uses a quicksort algorithm and allows you to sort the phonebook by: Name, Surname, Phone, Date of Birth or Address.
Default = Sort by Name.
You can sort it in ascending or descending order(optional) by filling in the second parameter with "descending" or "ascending".
Default = Ascending order.


### Author
Developer: Heine Pettersen
Github: https://github.com/heineP


### License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
