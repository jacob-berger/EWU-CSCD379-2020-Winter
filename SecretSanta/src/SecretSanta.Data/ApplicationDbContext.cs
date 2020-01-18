using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Data
{
    public class ApplicationDbContext : DbContext
    {
#nullable disable
        IHttpContextAccessor _IHttpContextAccessor;
        IHttpContextAccessor IHttpContextAccessor { get => _IHttpContextAccessor; set => _IHttpContextAccessor = value ?? throw new ArgumentNullException(nameof(IHttpContextAccessor)); }
#nullable enable
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public ApplicationDbContext(DbContextOptions dbContextOptions, IHttpContextAccessor httpContextAccessor) : base(dbContextOptions)
        {
            IHttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            _ = modelBuilder.Entity<Link>().HasKey(link => new { link.User, link.Group });


        }

        public override int SaveChanges()
        {
            //Need to do something
        }

        public override void OnModelCreating(Boolean boolean)
        {
            //Need to do something
        }
    }
}
