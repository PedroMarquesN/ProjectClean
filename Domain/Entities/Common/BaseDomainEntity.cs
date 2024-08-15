namespace ProjetoClean.Domain.Entities.Common;

public abstract class BaseDomainEntity
{
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
