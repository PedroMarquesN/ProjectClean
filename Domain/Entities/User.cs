﻿using ProjetoClean.Domain.Enums;

namespace ProjetoClean.Domain.Entities;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public Profile Profile { get; set; } = default!;


    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Role { get; set; } = Roles.TEAM_MEMBER.ToString();
}
