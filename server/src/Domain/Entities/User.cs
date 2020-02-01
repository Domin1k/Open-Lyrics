namespace Domain.Entities
{
    using Domain.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;

    public class User : Entity<int>
    {
        private string _username;
        private string _email;
        private byte[] _passHash;
        private byte[] _passSalt;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username
        {
            get => _username;
            set
            {
                _username = SetUsername(value);
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = SetEmail(value);
            }
        }

        public byte[] PasswordHash
        {
            get => _passHash;
            set
            {
                _passHash = SetHash(value);
            }
        }

        public byte[] PasswordSalt
        {
            get => _passSalt;
            set
            {
                _passSalt = SetSalt(value);
            }
        }

        public ICollection<Lyric> Lyrics { get; set; } = new List<Lyric>();

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
