using Telerik.SolidPrinciples.Models;

namespace Telerik.SolidPrinciples.Services
{
    /// <summary>
    /// Note that both interfaces are very similar—after all, the Service class accesses the methods of the Repository class, 
    /// but there is a method (GetPersonalContactFullName()) that is only present in the service class. 
    /// So if we used the same interface for both classes, the GetPersonalContactFullName() method would not be useful in the Repository 
    /// class, unnecessarily causing the use of duplicate code in addition to increasing coupling between classes and violating 
    /// the principle of Interface Segregation.
    /// </summary>
    public interface IContactService
    {
        Task<List<Contact>> FindAllContactsAsync();
        string GetPersonalContactFullName(Contact contact);
        Task<Guid> CreateContactAsync(Contact contact);
        Task UpdateContactAsync(Guid id, Contact updatedContact);
        Task DeleteContactAsync(Guid id);
    }
}
