﻿namespace ProjetoClean.WebApi.Models;

public class UserToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public string UserId { get; set; }
    public string Role { get; set; }
}
