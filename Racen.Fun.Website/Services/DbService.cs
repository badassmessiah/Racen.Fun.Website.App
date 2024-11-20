using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<ContactModels>> GetContactModelsAsync()
        {
            return await Task.Run(() => _context.ContactModels.ToList());
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.ContactModels.CountAsync();
        }

        public async Task CreateNewContactAsync(ContactModels contactModel)
        {
            await _context.ContactModels.AddAsync(contactModel);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await _context.ContactModels.AnyAsync(c => c.Email == email);
        }

    }
}