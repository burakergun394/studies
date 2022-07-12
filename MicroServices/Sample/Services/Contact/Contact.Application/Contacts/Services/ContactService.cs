using Contact.Application.Contacts.Dtos;

namespace Contact.Application.Contacts.Services;

public class ContactService : IContactService
{
    public ContactDto GetById(int id)
    {
        return new ContactDto
        {
            Id = id,
            FirstName = "Burak",
            LastName = "Ergün"
        };
    }
}
