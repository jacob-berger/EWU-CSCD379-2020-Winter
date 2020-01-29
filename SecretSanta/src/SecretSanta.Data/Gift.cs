using System;

namespace SecretSanta.Data
{
    public class Gift : FingerPrintEntityBase
    {
        public string Title
        {
            get => _Title;
            set => _Title = value ?? throw new ArgumentNullException(nameof(Title));
        }
        private string _Title = string.Empty;
        
        public string Description
        {
            get => _Description;
            set => _Description = value ?? throw new ArgumentNullException(nameof(Description));
        }
        private string _Description = string.Empty;
        
        public string Url
        {
            get => _Url;
            set => _Url = value ?? throw new ArgumentNullException(nameof(Url));
        }
        private string _Url = string.Empty;

#nullable disable
        public User User { get; set; }
#nullable enable
        public int UserId { get; set; }

        private Gift(string title, string url, string description, int userId)
        {
            _Title = title;
            _Url = url;
            _Description = description;
            UserId = userId;
        }

#pragma warning disable CA1062 //Cannot check for null when chaining constructors
        public Gift(string title, string url, string description, User user) : this(title, url, description, user.Id)
        {
            User = user;
        }
#pragma warning restore CA1062
    }
}
