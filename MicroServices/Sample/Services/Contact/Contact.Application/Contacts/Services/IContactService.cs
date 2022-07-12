using Contact.Application.Contacts.Dtos;

namespace Contact.Application.Contacts.Services;

public interface IContactService
{
    ContactDto GetById(int id);
}
