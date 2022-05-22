
SerieRepositorio repositorio = new SerieRepositorio();

int opcaoUsuario;

do
{
    opcaoUsuario = MenuOpcoes();
    switch (opcaoUsuario)
    {
        case 1:
            ListarSerie();
            break;
        case 2:
            InserirSerie();
            break;
        case 3:
            AtualizarSerie();
            break;
        case 4:
            ExcluirSerie();
            break;
        case 5:
            VisualizarSerie();
            break;
        case 6:
            Console.Clear();
            break;
        case 7:
            Console.WriteLine("Saindo...");
            break;
    }

} while (opcaoUsuario != 7);

void ListarSerie()
{
    Console.WriteLine("--------| LISTAR SÉRIES |--------");
    var lista = repositorio.Lista();

    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhume série cadastrada.");
        return;
    }

    foreach (var serie in lista)
    {
        Console.WriteLine("\nID: " + serie.GetId());
        Console.WriteLine(serie.ToString());
    }
}
void InserirSerie()
{
    Console.WriteLine("--------| INSERIR NOVA SÉRIE |--------");

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
    }

    Console.WriteLine("\nDigite o gênero entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.WriteLine("\nDigite o título da série: ");
    string entradaTitulo = Console.ReadLine();

    Console.WriteLine("\nDigite o Ano de lançamento da série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    Console.WriteLine("\nDigite a descrição da série: ");
    string entradaDescricao = Console.ReadLine();

    Serie novaSerie = new Serie(repositorio.ProximoId(), (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
    repositorio.Inserir(novaSerie);

}
void AtualizarSerie()
{
    Console.WriteLine("--------| ATUALIZAR SÉRIE |--------");

    Console.WriteLine("\nDigite o ID da série: ");
    int entradaId = int.Parse(Console.ReadLine());

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
    }

    Console.WriteLine("\nDigite o gênero entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.WriteLine("\nDigite o título da série: ");
    string entradaTitulo = Console.ReadLine();

    Console.WriteLine("\nDigite o Ano de lançamento da série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    Console.WriteLine("\nDigite a descrição da série: ");
    string entradaDescricao = Console.ReadLine();

    Serie novaSerie = new Serie(repositorio.ProximoId(), (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
    repositorio.Atualizar(entradaId, novaSerie);
}
void ExcluirSerie()
{
    Console.WriteLine("--------| EXCLUIR SÉRIE |--------");

    Console.WriteLine("\nDigite o ID da série: ");
    int entradaId = int.Parse(Console.ReadLine());

    repositorio.Excluir(entradaId);
}
void VisualizarSerie()
{
    Console.WriteLine("--------| VISUALIZAR SÉRIE |--------");

    Console.WriteLine("\nDigite o ID da série: ");
    int entradaId = int.Parse(Console.ReadLine());

    Console.WriteLine(repositorio.RetornarPorId(entradaId).ToString());
}
int MenuOpcoes()
{
    Console.WriteLine();
    Console.WriteLine("-----------| MENU |-----------");
    Console.WriteLine("Insira um valor: ");

    Console.WriteLine("1- Listar séries");
    Console.WriteLine("2- Inserir nova série");
    Console.WriteLine("3- Atualizar série");
    Console.WriteLine("4- Excluir série");
    Console.WriteLine("5- Visualizar série");
    Console.WriteLine("6- Limpar tela");
    Console.WriteLine("7- Sair");

    int opcaoUsuario = int.Parse(Console.ReadLine());
    return opcaoUsuario;
}
