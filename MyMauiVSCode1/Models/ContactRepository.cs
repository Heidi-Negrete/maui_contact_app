using System;

namespace MyMauiVSCode1.Models;

public static class ContactRepository
{
    public static List<Contact> _contacts = new List<Contact>
        {
            new Contact { ContactId = 1, Name = "John Doe", Phone = "555-1234", Email = "johndoe@email.com", Address = "123 Elm St" },
            new Contact { ContactId = 2, Name = "Jane Doe", Phone = "555-5678", Email = "janedoe@email.com", Address = "456 Oak St" },
            new Contact { ContactId = 3, Name = "Sammy Doe", Phone = "555-4321", Email = "samdoe@email.com", Address = "789 Pine St" }
        };

    public static List<Contact> GetContacts() => _contacts;
    public static Contact GetContactById(int contactId)
    {
        var contact = _contacts.FirstOrDefault(c => c.ContactId == contactId);
        if (contact != null)
        {
            return new Contact
            {
                ContactId = contact.ContactId,
                Name = contact.Name,
                Phone = contact.Phone,
                Email = contact.Email,
                Address = contact.Address
            };
        }
        else
        {
            return null;
        }
    }

    public static void UpdateContact(int contactId, Contact contact)
    {
        if (contactId != contact.ContactId) return;

        var contactToUpdate = _contacts.FirstOrDefault(c => c.ContactId == contactId);
        if (contactToUpdate != null)
        {
            // check out AutoMapper for a more elegant way to do this
            // wouldnt do this with a database.
            contactToUpdate.Name = contact.Name;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Address = contact.Address;
        }
    }

    public static void AddContact(Contact contact)
    {
        var maxId = _contacts.Max(x => x.ContactId);
        contact.ContactId = maxId + 1;
        _contacts.Add(contact);
    }
}
