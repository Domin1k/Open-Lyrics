﻿namespace WebAPI.Features.User.Models
{
    public class AuthenticateUserRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
