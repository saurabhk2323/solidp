using Telerik.SolidPrinciples.Models;

using Microsoft.EntityFrameworkCore;


namespace Telerik.SolidPrinciples.Data
{
    /// <summary>
    /// this class implements the single responsibility principle because it has a single well-defined responsibility, which is to
    /// deal with data persistence operations, providing methods to fetch, insert, update and delete contacts in the database
    /// </summary>
    public class ContactRepository: IContactRepository
    {
        private readonly ContactDbContext _db;

        public ContactRepository(ContactDbContext db)
        {
            _db = db;
        }

        public async Task<List<Contact>> FindAllContactsAsync()
        {
            return await _db.Contacts.ToListAsync();
        }

        public async Task<Contact> FindContactByIdAsync(Guid id)
        {
            var contact = await _db.Contacts.SingleOrDefaultAsync(x => x.Id == id);
            return contact;
        }

        public async Task<Guid> InsertAsync(Contact contact)
        {
            contact.Id = Guid.NewGuid();
            contact.CreatedOn = DateTimeOffset.Now;

            await _db.AddAsync(contact);
            await _db.SaveChangesAsync();

            return contact.Id;
        }

        public async Task UpdateAsync(Contact contact, Contact existingContact)
        {
            existingContact.FullName = contact.FullName;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.EmailAddress = contact.EmailAddress;
            existingContact.Address = contact.Address;
            existingContact.IsDeleted = contact.IsDeleted;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Contact contact)
        {
            _db.Remove(contact);
            await _db.SaveChangesAsync();
        }
    }
}
