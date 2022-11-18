using System;
using System.IO;

//Vou completar esta bela obra semana que vem,
//se não for demitido né vai que kkkk
//caracteres úteis: ─│┌┐└┘├┤┬┴┼
Console.Clear();
Console.WriteLine("┌───┐ ┌───┐");
Console.WriteLine("│┌─┐│ │┌─┐│");
Console.WriteLine("│└─┘│ ││ ││");
Console.WriteLine("│ ┌─┘ ││ ││");
Console.WriteLine("│ └─┐ ││ ││");
Console.WriteLine("│┌─┐│ ││ ││");
Console.WriteLine("│└─┘│ │└─┘│");
Console.WriteLine("└───┘ └───┘");
Console.WriteLine("\t\tTecnologia para a vida");
Console.WriteLine("");
Console.WriteLine("Pressione qualquer tecla para começar...");
Console.ReadKey(true);
Console.Clear();

bool on = true;
while (on)
{
    
    Console.WriteLine("O que você quer fazer?");
    Console.WriteLine("1 - Cadastrar Novo cliente");
    Console.WriteLine("2 - Ler dados do cliente");
    Console.WriteLine("3 - Cadastrar Novo produto");
    Console.WriteLine("4 - Ler dados do produto");
    Console.WriteLine("5 - Sair");
    int id = int.Parse(Console.ReadLine());
    switch(id)
    {
        case 1:
            Console.Clear();
            Console.Write("Digite o nome do Cliente: ");
            string nome = Console.ReadLine();
            Console.Write("O cliente é premium?(True ou False)\n");
            bool premiun = bool.Parse(Console.ReadLine());
            Console.Write("Digite o dia de nascimento do Cliente: ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Digite o mes de nascimento do Cliente: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Digite o ano de nascimento do Cliente: ");
            int ano = int.Parse(Console.ReadLine());

            Cliente cliente = new Cliente(nome, premiun, dia, mes, ano);
            cliente.Save();
            break;
        
        case 2:
            Console.Clear();
            Console.Write("Digite o nome do Cliente: ");
            nome = Console.ReadLine();
            Cliente.Load(nome);
            break;
        
        case 3:
            Console.Clear();
            Console.Write("Digite o nome do Produto: ");
            string nomepro = Console.ReadLine();
            Console.Write("Digite o preço do produto: ");
            float preco = float.Parse(Console.ReadLine());
            Console.Write("Digite o ano do lançamento do produto: ");
            int anopro = int.Parse(Console.ReadLine());
            Console.Write("Digite o tempo de garantia (em meses): ");
            int tempo = int.Parse(Console.ReadLine());

            Produto produto = new Produto (nomepro, preco, anopro, tempo);
            produto.Save();
            break;
        case 4:
            Console.Clear();
            Console.Write("Digite o nome do Produto: ");
            nome = Console.ReadLine();
            Produto.Load(nome);
            break;
        case 5:
            Console.Clear();
            on = false;
            break;
    }
}

public class Cliente
{
    public Cliente(string nome, bool premium, int dia, int mes, int ano)
    {
        this.Nome = nome;
        this.Premium = premium;
        this.DiaNascimento = dia;
        this.MesNascimento = mes;
        this.AnoNascimento = ano;
    }

    public string Nome { get; set; }
    public bool Premium { get; set; }
    public int DiaNascimento { get; set; }
    public int MesNascimento { get; set; }
    public int AnoNascimento { get; set; }

    public void Save()
    {
        StreamWriter writer = new StreamWriter(this.Nome + ".txt");

        writer.WriteLine(this.Nome);
        writer.WriteLine(this.Premium);
        writer.WriteLine(this.DiaNascimento);
        writer.WriteLine(this.MesNascimento);
        writer.WriteLine(this.AnoNascimento);

        writer.Close();
    }

    public static void Load(string nome)
    {
        StreamReader reader = new StreamReader(nome + ".txt");

        nome = reader.ReadLine();
        bool premiun = bool.Parse(reader.ReadLine());
        int dia = int.Parse(reader.ReadLine());
        int mes = int.Parse(reader.ReadLine());
        int ano = int.Parse(reader.ReadLine());
        
        Cliente cliente = new Cliente(nome, premiun, dia, mes, ano);
        Console.WriteLine($"Nome: {cliente.Nome}, Premium: {cliente.Premium}, Data de nascimento: {cliente.DiaNascimento}/{cliente.MesNascimento}/{cliente.AnoNascimento}");
    }
}

public class Produto
{
    public Produto(string nome, float preco, int ano, int garantia)
    {
        this.Nome = nome;
        this.Preco = preco;
        this.AnoDeLancamento = ano;
        this.TempoDeGarantia = garantia;
    }

    public string Nome { get; set; }
    public float Preco { get; set; }
    public int AnoDeLancamento { get; set; }
    public int TempoDeGarantia { get; set; }

    public void Save()
    {
        StreamWriter writer = new StreamWriter(this.Nome + ".txt");

        writer.WriteLine(this.Nome);
        writer.WriteLine(this.Preco);
        writer.WriteLine(this.AnoDeLancamento);
        writer.WriteLine(this.TempoDeGarantia);

        writer.Close();
    }

    public static void Load(string nome)
    {
        StreamReader reader = new StreamReader(nome + ".txt");

        nome = reader.ReadLine();
        float preco = float.Parse(reader.ReadLine());
        int ano = int.Parse(reader.ReadLine());
        int tempo = int.Parse(reader.ReadLine());
        
        Produto produto = new Produto(nome, preco, ano, tempo);
        Console.WriteLine($"Nome: {produto.Nome}, Preço: {produto.Preco}, Ano de lançamento: {produto.AnoDeLancamento}, Tempo de garantia: {produto.TempoDeGarantia} meses");
    }
}