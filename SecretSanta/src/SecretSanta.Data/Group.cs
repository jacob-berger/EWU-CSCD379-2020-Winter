using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace SecretSanta.Data
{
    public class Group : FingerPrintEntityBase
    {
		private string _Name = string.Empty;

		public string Name
		{
			get { return _Name; }
			set
			{
				_Name = value ?? throw new ArgumentNullException(nameof(Name));

			}
		}

		public ICollection<Link> Links { get; } = null!;

		private DbSet _DbSet = null!;
		public DbSet DbSet { get => _DbSet; set => _DbSet = value ?? throw new ArgumentNullException(nameof(DbSet)); }

	}
}
