using System.IO;
using System.Linq;
using System;
using static System.Console;
using System.Collections.Generic;

var days = getDays();
var bikes = getSharings();

// Pesquisador.MediaDia(bikes);
// Pesquisador.Crescimento(bikes);
// Pesquisador.DiferencaTrabalho(bikes, days);
Pesquisador.ExternoImpacto(bikes, days);


IEnumerable<DayInfo> getDays()
{
    StreamReader reader = new StreamReader("dayInfo.csv");
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        var data = reader.ReadLine().Split(',');
        DayInfo info = new DayInfo();

        info.Day = int.Parse(data[0]);
        info.Season = int.Parse(data[1]);
        info.IsWorkingDay = int.Parse(data[2]) == 1;
        info.Weather = int.Parse(data[3]);
        info.Temp = float.Parse(data[4].Replace('.', ','));
        yield return info;
    }

    reader.Close();
}

IEnumerable<BikeSharing> getSharings()
{
    StreamReader reader = new StreamReader("bikeSharing.csv");
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        var data = reader.ReadLine().Split(',');
        BikeSharing info = new BikeSharing();
        info.Day = int.Parse(data[0]);
        info.Casual = int.Parse(data[1]);
        info.Registered = int.Parse(data[2]);
        yield return info;
    }
    reader.Close();
}

public class Pesquisador
{
    public static void MediaDia(IEnumerable<BikeSharing> listbike)
    {
        // 1. Qual a média de alugueis de bicicletas em todo período? Sempre 
        // considere os aluguéis casuais junto aos registrados.

        // Entendi ser a média de alugueis por dia

        Console.WriteLine($"A média por dia é: {(listbike.Sum(a => a.Casual) + listbike.Sum(a => a.Registered))/listbike.Count()} alugueis de bicicleta por dia");
    }
    public static void Crescimento(IEnumerable<BikeSharing> listbike)
    {
        // 2. A empresa parece ter crescido, ou seja, aumentado os alugueis de 
        // cicletas ao longo do tempo? Utilize as médias a cada 30 dias para 
        // analisar isso. Dica: Você pode resolver isso com um GroupBy com 
        // uma divisão
        int vezes = listbike.Count()/30;
        for (int i = 1, j = 0 ; i < vezes; i++, j++)
        {
            float mediaMes = (listbike.Where(d => d.Day > 30*j && d.Day <= 30*i).Sum(b => b.Casual) + listbike.Where(d => d.Day > 30*j && d.Day <= 30*i).Sum(b => b.Registered)) / 30;
            Console.WriteLine($"A média do mes {i} = {mediaMes} alugueis de bicicleta por dia");
        }
    }
    public static void ExternoImpacto(IEnumerable<BikeSharing> listbike, IEnumerable<DayInfo> listday)
    {
        // 3. Como a estação, condições de tempo e temperatura impactam nos 
        // resultados? Responda para os três casos separadamente.
        var relacao = listbike.Join(listday,
                                    b => b.Day,
                                    d => d.Day,
                                    (b, d) => new{
                                        d.Season,
                                        aluguel = b.Casual + b.Registered,
                                    });
        var estacao = relacao.GroupBy(d => d.Season)
                            .Select(d => new {
                            Estacao = d.Key,
                            Alugueis = d.Sum(d => d.aluguel) / d.Count()
                        });

        foreach (var item in estacao)
        {
           Console.WriteLine($"Estação: {item.Estacao} -- Alugueis: {item.Alugueis}"); 
        }

        Console.WriteLine("\n");

        var relacao2 = listbike.Join(listday,
                                    b => b.Day,
                                    d => d.Day,
                                    (b, d) => new{
                                        d.Weather,
                                        aluguel = b.Casual + b.Registered,
                                    });
        var tempo = relacao.GroupBy(d => d.Season)
                            .Select(d => new {
                            Tempo = d.Key,
                            Alugueis = d.Sum(d => d.aluguel) / d.Count()
                        });

        foreach (var item in tempo)
        {
           Console.WriteLine($"Tempo: {item.Tempo} -- Alugueis: {item.Alugueis}"); 
        }

        Console.WriteLine("\n");
    }
    public static void DiferencaTrabalho(IEnumerable<BikeSharing> listbike, IEnumerable<DayInfo> listday)
    {
        // 4. Qual a média de aluguel de bicicletas nos dias de trabalho? E nos dias
        // que não se trabalha?
        var relacao = listbike.Join(listday,
                                    b => b.Day,
                                    d => d.Day,
                                    (b, d) => new{
                                        b.Day,
                                        aluguel = b.Casual + b.Registered,
                                        d.IsWorkingDay
                                    });
        var mediaTrabalha = relacao.Where(d => d.IsWorkingDay).Sum(d => d.aluguel) / relacao.Count();
        var mediaNTrabalha = relacao.Where(d => !d.IsWorkingDay).Sum(d => d.aluguel) / relacao.Count();

        Console.WriteLine($"Média em dia que trabalha é: {mediaTrabalha}\nMédia em dia que não trabalha é: {mediaNTrabalha}");
    }

    public static void Picos(IEnumerable<BikeSharing> listbike, IEnumerable<DayInfo> listday)
    {
        // 5. Quais são os picos, tanto de alta quanto de baixa para o aluguel de 
        // bicicletas e quais eram as condições (dia de trabalho, condições do 
        // tempo, etc) nesses dias.

    }
}

public class DayInfo
{
    public int Day { get; set; }
    public int Season { get; set; }
    public bool IsWorkingDay { get; set; }
    public int Weather { get; set; }
    public float Temp { get; set; }
}

public class BikeSharing
{
    public int Day { get; set; }
    public int Casual { get; set; }
    public int Registered { get; set; }
}