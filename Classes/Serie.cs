public class Serie : Entidade
{
    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Descricao { get; set; }
    private int Ano { get; set; }
    private bool Excluido { get; set; }

    public Serie(int Id, Genero genero, string titulo, string descricao, int ano)
    {
        this.Id = Id;
        this.Genero = genero;
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.Ano = ano;
        this.Excluido = false;
    }

    public int GetId()
    {
        return Id;
    }

    public override string ToString()
    {
        return "Gênero: " + Genero + "\nTítulo: " + Titulo + "\nDescrição: " + Descricao + "\nAno de lançamento: " + Ano + "\nExcluido: " + Excluido;
    }

    public void Excluir()
    {
        this.Excluido = true;
    }
}