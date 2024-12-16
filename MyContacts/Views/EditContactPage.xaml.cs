using MyContacts.Model;

namespace MyContacts.Views;

[QueryProperty(nameof(id), "id")]
public partial class EditContactPage : ContentPage
{
    ContactsRepository repository = new ContactsRepository();
    ContactInfo contact;

    public string id { get; set; }

    public EditContactPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        contact = await repository.GetContact(Int32.Parse(id));

        NameEntry.Text = contact.NameSurname;
        PhoneEntry.Text = contact.PhoneNumber;
        EmailEntry.Text = contact.Email;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        contact.NameSurname = NameEntry.Text;
        contact.PhoneNumber = PhoneEntry.Text;
        contact.Email = EmailEntry.Text;

        await repository.UpdateContact(contact);

        await Shell.Current.GoToAsync("..");
    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
