using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Business
{
    public class User
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Gift> Gifts { get; }

        public User(int id, string first, string last, List<Gift> gifts)
        {
            Id = id;
            FirstName = first ?? throw new ArgumentNullException(nameof(first));
            LastName = last ?? throw new ArgumentNullException(nameof(last));
            Gifts = gifts ?? new List<Gift>();
        }
    }
}
