using MyMauiVSCode1.Models;
using Contact = MyMauiVSCode1.Models.Contact;

namespace MyMauiVSCode1.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();

        List<Contact> contacts = ContactRepository.GetContacts();

        listContacts.ItemsSource = contacts;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        Console.WriteLine("Selected: " + e.SelectedItem);
        await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)e.SelectedItem).ContactId}");
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }

}