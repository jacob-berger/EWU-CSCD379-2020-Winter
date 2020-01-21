using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Data
{
    public class Link
    {
		public User User { get; set; }
		public Group Group { get; set; }
		public int GroupID { get; set; }
	}
}
