using Contacts;



PhoneBook phoneBook = new PhoneBook("ContactData.json");




// demonstration code
phoneBook.Search("jones");

phoneBook.Display(phoneBook.Contacts[0]);
phoneBook.Display(phoneBook.Contacts[1]);

phoneBook.Sort("","descending");

phoneBook.Display(phoneBook.Contacts[0]);
phoneBook.Display(phoneBook.Contacts[1]);









