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
            lblName.Text = contact.ToString();
        }
    }
}