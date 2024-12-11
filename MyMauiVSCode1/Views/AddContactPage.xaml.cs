using MyMauiVSCode1.Models;
using Contact = MyMauiVSCode1.Models.Contact;
namespace MyMauiVSCode1.Views;


public partial class AddContactPage : ContentPage
{
    public AddContactPage()
    {
        InitializeComponent();
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        ContactRepository.AddContact(new Contact
        {
            Name = contactControl.Name,
            Phone = contactControl.Phone,
            Email = contactControl.Email,
            Address = contactControl.Address
        });

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