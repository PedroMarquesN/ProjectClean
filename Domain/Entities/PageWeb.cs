namespace ProjetoClean.Domain.Entities;

public class PageWeb
{
    public long Id { get; set; }
    public string URL { get; set; } = string.Empty;

    public string description { get; set; } = string.Empty;

    // Construtor padrão
    public PageWeb() { }

    // Construtor com parâmetros
    public PageWeb(string url, string description)
    {
        URL = url;
        this.description = description;
    }
}
