using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racen.Fun.Website.Data;
using static Racen.Fun.Website.Components.Pages.Contact;

namespace Racen.Fun.Website.Services
{
    public class DbService
    {
        private readonly AppDbContext _context;

        public DbService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactModel>> GetContactModelsAsync()
        {
            return await Task.Run(() => _context.ContactModel.ToList());
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await Task.Run(() => _context.ContactModel.Count());
        }

        public async Task CreateNewContactAsync(ContactModel contactModel)
        {
            await _context.ContactModel.AddAsync(contactModel);
            await _context.SaveChangesAsync();
        }
    }
}