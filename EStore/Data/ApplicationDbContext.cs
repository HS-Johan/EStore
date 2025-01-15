using EStore.Areas.Admin.DataModel;
using EStore.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; } = default!;

        public DbSet<Product> Product { get; set; } = default!;

        public DbSet<Label> Label { get; set; } = default!;

        public DbSet<LookUp> LookUp { get; set; } = default!;

    }
}
