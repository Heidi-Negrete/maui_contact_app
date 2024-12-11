using MyMauiVSCode1.Models;
using Contact = MyMauiVSCode1.Models.Contact;

namespace MyMauiVSCode1.Views;

[QueryProperty("ContactId", "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
    public EditContactPage()
    {
        InitializeComponent();
    }

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(int.Parse(value));

            if (contact != null)
            {
                contactControl.Name = contact.Name;
                contactControl.Phone = contact.Phone;
                contactControl.Email = contact.Email;
                contactControl.Address = contact.Address;
            }
        }
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        contact.Name = contactControl.Name;
        contact.Phone = contactControl.Phone;
        contact.Email = contactControl.Email;
        contact.Address = contactControl.Address;

        ContactRepository.UpdateContact(contact.ContactId, contact);

        Shell.Current.GoToAsync("..");
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}