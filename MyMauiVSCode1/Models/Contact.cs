using System;

namespace MyMauiVSCode1.Models;

public class Contact
{
    public int ContactId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    public string Email { get; set; }

    // override ToString DON'T DO THIS. Use data binding instead. see the xaml file
    public override string ToString()
    {
        return $"{Name} - {Phone} - {Email}";
    }
}
