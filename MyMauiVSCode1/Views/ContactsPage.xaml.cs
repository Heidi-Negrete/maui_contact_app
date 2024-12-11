using System.Collections.ObjectModel;
using MyMauiVSCode1.Models;
using Contact = MyMauiVSCode1.Models.Contact;

namespace MyMauiVSCode1.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        loadContacts();
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

    private void contextDelete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;

        if (contact != null)
        {
            ContactRepository.DeleteContact(contact.ContactId);
            loadContacts();
        }
        return;
    }

    private void loadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContact(e.NewTextValue));
        listContacts.ItemsSource = contacts;
    }
}