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
                entryName.Text = contact.Name;
                entryPhone.Text = contact.Phone;
                entryEmail.Text = contact.Email;
                entryAddress.Text = contact.Address;
            }
        }
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            DisplayAlert("Error", "Name is required", "OK");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            // refactor with builder pattern for only one display alert
            foreach (var error in emailValidator.Errors)
            {
                DisplayAlert("Error", error.ToString(), "OK");
            }
            return;
        }

        contact.Name = entryName.Text;
        contact.Phone = entryPhone.Text;
        contact.Email = entryEmail.Text;
        contact.Address = entryAddress.Text;

        ContactRepository.UpdateContact(contact.ContactId, contact);

        Shell.Current.GoToAsync("..");
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}