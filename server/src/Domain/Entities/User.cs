namespace Domain.Entities
{
    using Domain.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;

    public class User : Entity<int>
    {
        public User(string firstName, string lastName, string username, string email, byte[] passwordHash, byte[] passwordSalt, ICollection<Lyric> lyrics)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = SetUsername(username);
            Email = SetEmail(email);
            PasswordHash = SetHash(passwordHash);
            PasswordSalt = SetSalt(passwordSalt);
            Lyrics = lyrics ?? new List<Lyric>();
        }

        public string FirstName { get; }

        public string LastName { get; }
        
        public string Username { get; }

        public string Email { get; }
        
        public byte[] PasswordHash { get; }
        
        public byte[] PasswordSalt { get; }

        public ICollection<Lyric> Lyrics { get; }

        private string SetUsername(string username)
        {
            if (string.IsNullOrEmpty(username?.Trim()))
            {
                throw new DomainException($"Parameter - {nameof(username)} cannot be null!");
            }

            return username;
        }

        private byte[] SetHash(byte[] storedHash)
        {
            if (storedHash == null)
            {
                throw new DomainException($"Parameter - {nameof(storedHash)} cannot be null!");
            }

            if (storedHash.Length != 64)
            {
                throw new DomainException("Invalid length of password hash (64 bytes expected).");
            }
            return storedHash;
        }

        private byte[] SetSalt(byte[] storedSalt)
        {
            if (storedSalt == null)
            {
                throw new DomainException($"Parameter - {nameof(storedSalt)} cannot be null!");
            }

            if (storedSalt.Length != 128)
            {
                throw new DomainException("Invalid length of password salt (128 bytes expected).");
            }

            return storedSalt;
        }


        private string SetEmail(string email)
        {
            try
            {
                var m = new MailAddress(email);
                return m.Address;
            }
            catch (Exception)
            {
                throw new DomainException($"Provided {email} is not valid email address!");
            }
        }
    }
}
