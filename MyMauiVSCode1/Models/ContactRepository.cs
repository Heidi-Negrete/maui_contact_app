using System;

namespace MyMauiVSCode1.Models;

public static class ContactRepository
{
    public static List<Contact> _contacts = new List<Contact>
        {
            new Contact { ContactId = 1, Name = "John Doe", Phone = "555-1234", Email = "johndoe@email.com" },
            new Contact { ContactId = 2, Name = "Jane Doe", Phone = "555-5678", Email = "janedoe@email.com" },
            new Contact { ContactId = 3, Name = "Sammy Doe", Phone = "555-4321", Email = "samdoe@email.com" }
        };

    public static List<Contact> GetContacts() => _contacts;
    public static Contact GetContactById(int contactId)
    {
        return _contacts.FirstOrDefault(c => c.ContactId == contactId);
    }
}
