using Microsoft.EntityFrameworkCore;
using Database;
using Models;

namespace Controllers
{
    public class PhonebookController
    {
        public async Task AddNewContact(Phonebook contact)
        {
            using (var context = new PhonebookDbContext())
            {
                await context.Phonebooks.AddAsync(contact);
                await context.SaveChangesAsync();
            }
            Console.WriteLine("Added Successfully");
        }

        public async Task ModifyContact(Phonebook contact, Guid id)
        {
            using (var context = new PhonebookDbContext())
            {
                var res = await context.Phonebooks.FindAsync(id);
                if (res is null)
                {
                    Console.WriteLine("Contact Not found");
                    return;
                }
                else
                {
                    if (contact.Name is not null) res.Name = contact.Name;
                    if (contact.Email is not null) res.Email = contact.Email;
                    if (contact.Address is not null) res.Address = contact.Address;
                    if (contact.PhoneNumber is not null) res.PhoneNumber = contact.PhoneNumber;
                    await context.SaveChangesAsync();
                }
            }
            Console.WriteLine("Added Successfully");
        }

        public async Task DeleteContact(Guid id)
        {
            using (var context = new PhonebookDbContext())
            {
                var res = await context.Phonebooks.FindAsync(id);
                if (res is null)
                {
                    Console.WriteLine("Contact Not found");
                    return;
                }
                else
                {
                    context.Remove(res);
                    await context.SaveChangesAsync();
                }
            }
            Console.WriteLine("Deleted Successfully");
        }



        public async Task<List<Phonebook>> GetAllContacts()
        {
            using (var context = new PhonebookDbContext())
            {
                var contacts = await context.Phonebooks.ToListAsync();
                return contacts;
            }
        }
    }
}
