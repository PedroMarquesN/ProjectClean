namespace ProjetoClean.Domain.Entities;

public class Profile
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Adress { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string BitrhDate { get; set; } = string.Empty;

    public long UserId { get; set; }
    public User User { get; set; } = default!;
}
