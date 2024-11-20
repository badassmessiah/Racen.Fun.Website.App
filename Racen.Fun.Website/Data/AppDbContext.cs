using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Racen.Fun.Website.Components.Pages.Contact;

namespace Racen.Fun.Website.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ContactModel> ContactModel { get; set; }
    }
}