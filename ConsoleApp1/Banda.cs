//Screen Sound

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> bandasRegistradas = new List<string> { "U2", "The Beatles", "Calipto"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("U2", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("Hello", new List<int> { 10, 7, 9 });

void Exibirlogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    Exibirlogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para visualizar todas as banda");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarbandasRegistradas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            ExibirMedia();
            break;
        case -1:
            Console.WriteLine("Tchau");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das Bandas");
    Console.Write("digite o nome da banda: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarbandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Bandas Registradas");
    //for (int i = 0; i < bandasRegistradas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {bandasRegistradas[i]}");
    //}
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");

}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.WriteLine("Digite qual banda deseja avaliar:");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média da banda");
    Console.WriteLine("Digite qual a banda que deseja saber a média: ");
    string nomeBandaMedia = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBandaMedia))
    {
        List<int> notaMedia = bandasRegistradas[nomeBandaMedia];
        if (notaMedia.Count > 0)
        {
            double mediaBanda = notaMedia.Average();
            Console.WriteLine($"A nota media da banda {nomeBandaMedia} é: " + mediaBanda);
        }
        else
        {
            Console.WriteLine($"A banda {nomeBandaMedia} não tem nota");
        }
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBandaMedia} não foi encontrada");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();