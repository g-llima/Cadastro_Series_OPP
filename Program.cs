
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
    Console.WriteLine("\nDigite 'x' para sair.\n");
    bool isLoopingAS = true;
    do
    {
        try
        {
            Console.Write("\nDigite o ID da série: ");
            string entradaId = Console.ReadLine();
            if (entradaId == "x") { isLoopingAS = false; return; }

            repositorio.RetornarPorId(int.Parse(entradaId));

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
            repositorio.Atualizar(int.Parse(entradaId), novaSerie);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSérie não encontrada.\n");
            Console.ResetColor();
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nValor inválido.\n");
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e);
            Console.ResetColor();
        }
    } while (isLoopingAS);

}
void ExcluirSerie()
{
    Console.WriteLine("--------| EXCLUIR SÉRIE |--------");
    Console.WriteLine("\nDigite 'x' para sair.\n");
    bool isLoopingE = true;

    do
    {
        try
        {
            Console.Write("\nDigite o ID da série: ");
            string entradaId = Console.ReadLine();
            if (entradaId == "x") { isLoopingE = false; return; }

            repositorio.Excluir(int.Parse(entradaId));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSérie excluida.\n");
            Console.ResetColor();

            isLoopingE = false;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSérie não encontrada.\n");
            Console.ResetColor();
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nValor inválido.\n");
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e);
            Console.ResetColor();
        }

    } while (isLoopingE);


}
void VisualizarSerie()
{
    Console.WriteLine("--------| VISUALIZAR SÉRIE |--------");
    bool isLoopingVS = true;
    Console.WriteLine("\nDigite 'x' para sair.\n");

    do
    {
        try
        {
            Console.Write("\n\nDigite o ID da série: ");

            string entradaId = Console.ReadLine();
            if (entradaId == "x") { isLoopingVS = false; return; }

            string serie = repositorio.RetornarPorId(int.Parse(entradaId)).ToString();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSérie encontrada !\n");
            Console.ResetColor();

            Console.WriteLine(serie);

            isLoopingVS = false;

        }
        catch (ArgumentOutOfRangeException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSérie não encontrada.\n");
            Console.ResetColor();
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nValor inválido.\n");
            Console.ResetColor();
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e);
            Console.ResetColor();
        }
    } while (isLoopingVS);





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
