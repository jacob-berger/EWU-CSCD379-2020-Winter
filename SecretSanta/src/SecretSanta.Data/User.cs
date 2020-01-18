using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace SecretSanta.Data
{
    public class User : FingerPrintEntityBase
    {
        public string FirstName { get => _FirstName; set => _FirstName = value ?? throw new ArgumentNullException(nameof(FirstName)); }
        private string _FirstName = string.Empty;
        public string LastName { get => _LastName; set => _LastName = value ?? throw new ArgumentNullException(nameof(LastName)); }
        private string _LastName = string.Empty;
        public ICollection<Gift> Gifts
        {
            get { return Gifts; }
            set
            {
                Gifts = value ?? throw new ArgumentNullException(nameof(Gifts));
            }
        }
        public ICollection<Link> Links
        {
            get { return Links; }
            set
            {
                Links = value ?? throw new ArgumentNullException(nameof(Links));
            }
        }

        public User? Santa { get; set; }

        private DbSet _DbSet;
        public DbSet DbSet { get => _DbSet; set => _DbSet = value ?? throw new ArgumentNullException(nameof(DbSet)); }
    }
}
