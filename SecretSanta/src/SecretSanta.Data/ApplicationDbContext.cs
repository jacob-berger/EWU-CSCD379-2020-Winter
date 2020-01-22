using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecretSanta.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<Group> Groups { get; }
        public DbSet<Gift> Gifts { get; }
        IHttpContextAccessor _IHttpContextAccessor;
        IHttpContextAccessor IHttpContextAccessor { get => _IHttpContextAccessor; set => _IHttpContextAccessor = value ?? throw new ArgumentNullException(nameof(IHttpContextAccessor)); }
#nullable disable
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public ApplicationDbContext(DbContextOptions dbContextOptions, IHttpContextAccessor httpContextAccessor) : base(dbContextOptions)
        {
            IHttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
#nullable enable

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Link>().HasKey(link => new { link.User, link.Group });

            modelBuilder.Entity<Link>().HasOne(link => link.User).WithMany(link => link.Links).HasForeignKey(link => link.User.Id);

            modelBuilder.Entity<Link>().HasOne(link => link.Group).WithMany(link => link.Links).HasForeignKey(link => link.GroupID);

        }
        
        public override int SaveChanges()
        {
            AddFingerPrinting();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddFingerPrinting();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddFingerPrinting()
        {
            var added = ChangeTracker.Entries().Where(record => record.State == EntityState.Modified);

            var modified = ChangeTracker.Entries().Where(record => record.State == EntityState.Added);

            foreach (var record in added)
            {
                var entry = record.Entity as FingerPrintEntityBase;

                if (entry != null)
                {
                    entry.CreatedBy = entry.ModifiedBy = _IHttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value ?? "";
                    entry.CreatedOn = entry.ModifiedOn = DateTime.Now;
                }
            }

            foreach (var record in modified)
            {
                var entry = record.Entity as FingerPrintEntityBase;

                if (entry != null)
                {
                    entry.ModifiedBy = _IHttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value ?? "";
                }
            }
        }
    }
}
